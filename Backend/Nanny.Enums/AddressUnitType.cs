using System;
using System.Linq;

namespace Nanny.Enums
{
    public enum AddressUnitType
    {
        /// <summary>
        /// указывает точный почтовый адрес
        /// </summary>
        StreetAddress,
        /// <summary>
        /// указывает шоссе с названием (например, "US 101")
        /// </summary>
        Route,
        /// <summary>
        /// указывает крупные перекрестки, как правило, пересечения двух крупных дорог
        /// </summary>
        Intersection,
        /// <summary>
        /// указывает политическую единицу. Чаще всего такой тип используется для обозначения некоторых административных объектов
        /// </summary>
        Political,
        /// <summary>
        ///  указывает государственную политическую единицу и обычно представляет собой тип наивысшего порядка, который возвращается геокодировщиком
        /// </summary>
        Country,
        /// <summary>
        /// указывает гражданскую единицу первого порядка ниже уровня страны. В США такими административными уровнями являются штаты. Эти административные уровни 
        /// </summary>
        AdministrativeAreaLevel1,
        /// <summary>
        /// указывает гражданскую единицу второго порядка ниже уровня страны. В США такими административными уровнями являются округи. Эти административные уровни используются не во всех странах
        /// </summary>
        AdministrativeAreaLevel2,
        /// <summary>
        /// указывает гражданскую единицу третьего порядка ниже уровня страны. Такой тип представляет меньшее административное подразделение. Эти административные уровни используются не во всех странах
        /// </summary>
        AdministrativeAreaLevel3,
        /// <summary>
        /// указывает гражданскую единицу четвертого порядка ниже уровня страны. Такой тип представляет меньшее административное подразделение. Эти административные уровни используются не во всех странах
        /// </summary>
        AdministrativeAreaLevel4,
        /// <summary>
        /// указывает гражданскую единицу пятого порядка ниже уровня страны. Такой тип представляет меньшее административное подразделение. Эти административные уровни используются не во всех странах
        /// </summary>
        AdministrativeAreaLevel5,
        /// <summary>
        /// указывает общепринятое альтернативное название единицы
        /// </summary>
        ColloquialArea,
        /// <summary>
        /// указывает политическую единицу в составе города
        /// </summary>
        Locality,
        /// <summary>
        /// указывает гражданскую единицу первого порядка ниже уровня населенного пункта. Для некоторых местоположений возможно предоставление одного из дополнительных типов: от sublocality_level_1 до sublocality_level_5. Каждый уровень ниже населенного пункта является гражданской единицей. Большее значение указывает меньшую географическую область
        /// </summary>
        Sublocality,
        SublocalityLevel5,
        SublocalityLevel4,
        SublocalityLevel3,
        SublocalityLevel2,
        SublocalityLevel1,

        /// <summary>
        /// указывает именованный район
        /// </summary>
        Neighborhood,
        /// <summary>
        /// указывает именованное местоположение, обычно одно или несколько зданий с общепринятым названием
        /// </summary>
        Premise,
        /// <summary>
        /// указывает единицу первого порядка ниже именованного местоположения, обычно одно здание в границах комплекса зданий с общепринятым названием
        /// </summary>
        Subpremise,
        /// <summary>
        /// указывает почтовый индекс в том виде, в котором он используется в стране для обработки почты
        /// </summary>
        PostalCode,
        /// <summary>
        /// указывает важный природный объект
        /// </summary>
        NaturalFeature,
        /// <summary>
        /// указывает аэропорт
        /// </summary>
        Airport,
        /// <summary>
        /// указывает парк с названием
        /// </summary>
        Park,
        /// <summary>
        /// указывает определенный почтовый ящик
        /// </summary>
        PostBox,
        /// <summary>
        /// указывает точный номер дома
        /// </summary>
        StreetNumber,
        /// <summary>
        /// указывает этаж в адресе здания
        /// </summary>
        Floor,
        /// <summary>
        /// указывает комнату в адресе здания
        /// </summary>
        Room,

        Geocode,
        PointOfInterest,
        PostalCodePrefix,
        PostalCodeSuffix,
        PostalTown,
        TransitStation,

        Unrecognized = 500
    }

    public static class AddressUnitParser
    {
        public static AddressUnitType Get(string type)
        {
            type = type.Replace("_", "");

            var names = Enum.GetNames(typeof(AddressUnitType));
            var found = names.FirstOrDefault(n => n.Equals(type, StringComparison.CurrentCultureIgnoreCase));
            if (found == null)
            {
                return AddressUnitType.Unrecognized;
            }

            return (AddressUnitType)Enum.Parse(typeof(AddressUnitType), found);
        }
    }
}
