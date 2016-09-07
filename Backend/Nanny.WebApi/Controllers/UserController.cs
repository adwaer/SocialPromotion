using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Http;
using Adwaer.Identity.Controllers;
using Adwaer.Identity.ViewModel;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Nanny.Commands;
using Nanny.Domain.Entities;
using Nanny.Enums;
using Nanny.Queries;
using Nanny.WebApi.ViewModel;
using Newtonsoft.Json.Linq;

namespace Nanny.WebApi.Controllers
{
    public class UserController : UserControllerBase<SimpleCustomerAccount, RegistrationViewModel>
    {
        private readonly UserManager<SimpleCustomerAccount, Guid> _userManager;
        private readonly IMapper _mapper;
        private readonly SendEmailCommand _sendEmailCommand;
        private readonly AddressUnitByShortNameQuery _addressUnitByShortNameQuery;
        private readonly CountryQuery _countryQuery;

        public UserController(UserManager<SimpleCustomerAccount, Guid> userManager, IMapper mapper,
            SendEmailCommand sendEmailCommand, AddressUnitByShortNameQuery addressUnitByShortNameQuery,
            CountryQuery countryQuery)
            : base(userManager, mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
            _sendEmailCommand = sendEmailCommand;
            _addressUnitByShortNameQuery = addressUnitByShortNameQuery;
            _countryQuery = countryQuery;
        }

        public override async Task<IHttpActionResult> Post(RegistrationViewModel regModel)
        {
            var addressUnits = new List<AddressUnitViewModel>();
            var details = new AddressDetailsViewModel();
            regModel.Customer.Address = new AddressViewModel
            {
                ApiResult = regModel.Customer.AddressJson,
                UnitsAddressUnitViewModels = addressUnits,
                Details = details
            };

            if ((int)regModel.Customer.SearchType > 3 && !regModel.Customer.BirthDate.HasValue)
            {
                return BadRequest("bithtdate_required");
            }

            if (!ValidateAddress(regModel.Customer.AddressJson))
            {
                return BadRequest("address_not_valid");
            }

            // fill address
            var address = JObject.Parse(regModel.Customer.AddressJson);
            foreach (var component in address["address_components"])
            {
                var name = component["long_name"].Value<string>();
                var shortname = component["short_name"].Value<string>();
                var type = component["types"].First.Value<string>();
                var unitType = AddressUnitParser.Get(type);

                if (unitType == AddressUnitType.Country)
                {
                    regModel.Customer.Address.Country = await _countryQuery.Execute(shortname);
                }

                var addressUnit = await _addressUnitByShortNameQuery.Execute(shortname, unitType);
                if (addressUnit != null)
                {
                    addressUnits.Add(_mapper.Map<AddressUnitViewModel>(addressUnit));
                }
                else
                {
                    addressUnits.Add(new AddressUnitViewModel
                    {
                        Name = name,
                        ShortName = shortname,
                        Type = unitType
                    });
                }
            }

            // fill details
            var location = address["geometry"]["location"];
            details.Lat = location["lat"].Value<double>();
            details.Lng = location["lng"].Value<double>();
            details.Components = address["address_components"].ToString();
            details.DetailsId = address["id"].Value<string>();
            details.PlaceId = address["place_id"].Value<string>();
            details.Reference = address["reference"].Value<string>();
            details.Scope = address["scope"].Value<string>();
            details.Types = string.Join(";", address["types"].Values<string>());
            details.Url = address["url"].Value<string>();
            details.UtcOffset = address["utc_offset"].Value<string>();

            return await base.Post(regModel);
        }

        protected override async Task RegistrationCompleted(Guid id)
        {
            // becouse of user manager async disposing
            //var userManager = _scope.Get<UserManager<SimpleCustomerAccount, Guid>>();

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(id);
            var user = await _userManager.FindByIdAsync(id);

            string host = ConfigurationManager.AppSettings["frontendUri"];

            await _sendEmailCommand.Execute(new EmailPublish
            {
                Email = user.Email,
                Body =
                    $"Регистрация на сайте <a href=\"{host}\"> Наша няня </a>. Для подтверждения пароля перейдите по <a href=\"{host}#/confirm_email?userId={id}&token={token}\"> ссылке </a>",
                Subject = "Регистрация на сайте Наша няня"
            });
        }

        [HttpPost]
        [Route("api/user/{userId}/confirm")]
        public override Task<IHttpActionResult> Confirm(Guid userId, ConfirmByTokenViewModel model)
        {
            return base.Confirm(userId, model);
        }

        [HttpPost]
        [Route("api/user/{email}/beginrestore")]
        public async Task<IHttpActionResult> BeginRestore(string email)
        {
            string host = ConfigurationManager.AppSettings["frontendUri"];
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                await _sendEmailCommand.Execute(new EmailPublish
                {
                    Email = email,
                    Body =
                        $"Восстановление пароля на сайте <a href=\"{host}\"> Наша няня </a>. Аккаунт с данным email не найден.",
                    Subject = "Восстановление пароля на сайте Наша няня"
                });

                return Ok();
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user.Id);

            await _sendEmailCommand.Execute(new EmailPublish
            {
                Email = user.Email,
                Body =
                    $"Восстановление пароля на сайте <a href=\"{host}\"> Наша няня </a>. Для восстановления пароля перейдите по <a href=\"{host}#/restore_pwd?userId={user.Id}&token={token}\"> ссылке </a>",
                Subject = "Восстановление пароля на сайте Наша няня"
            });

            return Ok();
        }


        [HttpPost]
        [Route("api/user/{userId}/restore")]
        public override Task<IHttpActionResult> Restore(Guid userId, RestorePasswordViewModel model)
        {
            return base.Restore(userId, model);
        }

        [HttpGet]
        [Route("api/user/{email}/isemailbusy")]
        public async Task<IHttpActionResult> IsEmailBusy(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return Ok(user != null);
        }

        #region private
        private bool ValidateAddress(string addressJson)
        {
            var address = JObject.Parse(addressJson);
            foreach (var component in address["address_components"])
            {
                //var name = component["long_name"].Value<string>();
                //var shortname = component["short_name"].Value<string>();
                var type = component["types"].First.Value<string>();
                var unitType = AddressUnitParser.Get(type);

                if (unitType == AddressUnitType.PostalCode
                    || unitType == AddressUnitType.Route)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}
