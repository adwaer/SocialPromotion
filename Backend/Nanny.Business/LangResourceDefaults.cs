using System.Collections.Generic;

namespace Nanny.Business
{
    public static class LangResourceDefaults
    {
        public static readonly Dictionary<string, Dictionary<string, string>> LangResources = new Dictionary<string, Dictionary<string, string>>
        {
            ["landing"] = new Dictionary<string, string>
            {
                ["brand"] = "Наша няша"
            },
            ["metro"] = new Dictionary<string, string>
            {
                ["kazan_prospect_pobedy"] = "Проспект победы",
                ["kazan_gorky"] = "Горки",
                ["kazan_ametievo"] = "Аметьево",
                ["kazan_sukonnaya_sloboda"] = "Суконная слобода",
                ["kazan_ploshad_tukaya"] = "Площадь тукая",
                ["kazan_kremlin"] = "Кремлевская",
                ["kazan_yashlek"] = "Яшьлек",
                ["kazan_kozia_sloboda"] = "Козья слобода",
                ["kazan_severny_vokzal"] = "Северный вокзал",
                ["kazan_aviastroy"] = "Авиастроительная",
                ["moscow_tverskaya"] = "Тверская",

            },
            ["workers"] = new Dictionary<string, string>
            {
                ["range_until"] = "Расстояние до",
                ["search_result"] = "Результаты поиска",
                ["filters_me"] = "меня",
                ["filters_address"] = "адреса",
                ["filters_metro"] = "метро",
                ["filters_apply"] = "Применить",
                ["on_range"] = "на расстоянии",
                ["workerType_nannywork"] = "Няни",
                ["workerType_nursework"] = "Сиделки",
                ["workerType_housekeeperwork"] = "Домработницы",
                ["workerType_nanny"] = "Няня",
                ["workerType_nurse"] = "Сиделка",
                ["workerType_housekeeper"] = "Домработница",
                ["workerType_zoonyanya"] = "Зооняня",
                ["workerType_tutor"] = "Репетитор",
                ["workerType_zoonyanyawork"] = "Работу зооняни",
                ["workerType_tutorwork"] = "Работу репетитор"
            },
            ["common"] = new Dictionary<string, string>
            {
                ["in"] = "в",
                ["from"] = "от",
                ["kilometers"] = "км",
                ["meters"] = "м",
                ["logon"] = "Войти"
            },
            ["education"] = new Dictionary<string, string>
            {
                ["education"] = "Образование",
                ["high"] = "Высшее",
                ["pedagogical"] = "Педагогическое",
                ["medical"] = "Медицинское",
                ["сollege"] = "Колледж",
                ["montessori"] = "Курсы Монтессори",
                ["nannies"] = "Курсы нянь (ухода за детьми)",
                ["firstaid"] = "Курсы первой помощи",
                ["student"] = "Студент",
                ["carers_courses"] = "Курсы сиделок",
                ["nurse_course"] = "Курсы медсестер",
            },
            ["working_condition"] = new Dictionary<string, string>
            {
                ["working_condition"] = "Условия работы",
                ["can_travel"] = "Могу путешествовать с семьей",
                ["with_animals"] = "Могу работать в доме с животными",
                ["can_night"] = "Могу работать по ночам",
                ["can_move"] = "Готов переехать в другой город"
            },
            ["working_terms"] = new Dictionary<string, string>
            {
                ["working_terms"] = "Срок работы",
                ["long_time"] = "На долгий срок",
                ["season"] = "На 1-3 месяца (на сезон)",
                ["necessity"] = "По необходимости"
            },
            ["working_skills"] = new Dictionary<string, string>
            {
                ["working_skills"] = "Профессиональные умения",
                ["with_disabled"] = "Работа с детьми-инвалидами",
                ["home_works"] = "Помощь в выполнении домашних заданий",
                ["clean_room"] = "Помощь в уборке детской комнаты",
                ["events"] = "Организация детских мероприятий",
                ["care"] = "Детская гигиена",
                ["bathing"] = "Купание детей",
                ["accompnying"] = "Сопровождение детей",
                ["cooking"] = "Приготовление пищи",
                ["clean_home"] = "Уборка в доме",
                ["keeping_order"] = "Поддержание порядка",
                ["clothes_iron"] = "Глажка одежды",
                ["buying_products"] = "Покупка продуктов",
                ["care_pet"] = "Уход за домашними животными",
                ["plant_care"] = "Уход за растениями",

                ["sport_physiotherapy"] = "Занятия лечебной физкультурой",
                ["tube_feeding_diet"] = "Зондовое питание",
                ["patient_movement"] = "Поднятие/передвижение пациента",
                ["help_change_catheter"] = "Помощь в смене катетера",

                ["reception_desk"] = "Прием и обслуживание гостей",
                ["accounting_expenses_paying_bills"] = "Учет расходов, оплата счетов",
                ["controlling_other_domestic_workers"] = "Управление другими домашними работниками",
                ["own_equipment_harvesting"] = "Собственная техника для уборки",
                ["own_detergents"] = "Собственные моющие средства",
                ["babysitting"] = "Присмотр за детьми",
                ["help_sick_and_elderly"] = "Помощь больным и престарелым"
            },
            ["working_experience_age"] = new Dictionary<string, string>
            {
                ["working_experience_age"] = "Опыт работы (возраст детей)",
                ["year"] = "до года",
                ["one_three"] = "1-3 года",
                ["four_six"] = "4-6 лет",
                ["seven_ten"] = "7-10 лет",
                ["ten_older"] = "старше 10 лет"
            },
            ["languages"] = new Dictionary<string, string>
            {
                ["russian"] = "Русский",
                ["english"] = "Английский",
                ["german"] = "Немецкий",
                ["french"] = "Французский",
                ["spanish"] = "Испанский",
                ["italian"] = "Итальянский",
                ["ukrainian"] = "Украинский",
                ["tatar"] = "Татарский",
                ["armenian"] = "Армянский",
                ["georgian"] = "Грузинский",
                ["kazakh"] = "Казахский",
                ["hebrew"] = "Иврит",
                ["finnish"] = "Финский",
                ["swedish"] = "Шведский",
            },
            ["liveinout"] = new Dictionary<string, string>
            {
                ["in"] = "только с проживанием",
                ["in_or_out"] = "с проживанием или без",
                ["out"] = "без проживания"
            },
            ["employment"] = new Dictionary<string, string>
            {
                ["full"] = "полная занятость",
                ["part"] = "частичная занятость",
                ["full_or_part"] = "полная или частичная занятость"
            },
            ["children_count"] = new Dictionary<string, string>
            {
                ["one"] = "один ребенок",
                ["one_two"] = "один или два ребенка",
                ["any"] = "любое количество"
            },
            ["worship"] = new Dictionary<string, string>
            {
                ["atheist"] = "Атеист/агностик (выбрано по умолчанию)",
                ["orthodox"] = "Православный",
                ["catholic"] = "Католик",
                ["christia"] = "Христианин другой конфессии",
                ["muslim"] = "Мусульманин",
                ["buddhist"] = "Буддист",
                ["other"] = "Другое"
            },
            ["aboutnanny"] = new Dictionary<string, string>
            {
                ["first"] = "Раскажите о своем опыте работы с детьми",
                ["second"] = "Если у вас есть какое-нибудь специальное образование, которое вы можете применить в работе няни — напишите об этом",
                ["third"] = "Расскажите, откуда вы родом. Много ли детей было в семье, были ли младшие братья и сестры?",
                ["fourth"] = "Расскажите о себе. Какой вы человек, что для вас важно в жизни?"
            },
            ["aboutnurse"] = new Dictionary<string, string>
            {
                ["first"] = "Раскажите о своем опыте работы с больными и престарелыми людьми",
                ["second"] = "Если у вас есть какое-нибудь специальное образование, которое вы можете применить в работе сиделки— напишите об этом",
                ["third"] = "Расскажите, откуда вы родом. Приходилось ли вам ухаживать за больными или прастарелыми родственниками?",
                ["fourth"] = "Расскажите о себе. Какой вы человек, что для вас важно в жизни?"
            },
            ["abouthousekeeper"] = new Dictionary<string, string>
            {
                ["first"] = "Раскажите о своем опыте работы по дому",
                ["second"] = "Расскажите, откуда вы родом. Приходилось ли вам заниматься домашним хозяйством в вашей семье?",
                ["third"] = "Расскажите о себе. Какой вы человек, что для вас важно в жизни?"
            },
            ["choice"] = new Dictionary<string, string>
            {
                ["citizenship"] = "Гражданство РФ",
                ["right_work"] = "Право на работу в РФ",
                ["have_children"] = "Есть свои дети",
                ["not_smoke"] = "Не курю",
                ["have_driver_license"] = "Есть водительские права",
                ["have_car"] = "Есть свой автомобиль"
            }
        };

        public static Dictionary<string, string> Get(string id, string culture)
        {
            return LangResources[id];
        }
    }
}
