using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;

namespace KeyValueMapping.Models
{
    public class MappingManagement
    {
        //private List<KeyValuePair<string, string>> _encodingCharacterMap;

        //public MappingManagement()
        //{
        //    // _path = path;

        //    //_encodingCharacterMap = new List<KeyValuePair<string, string>>
        //    //{
        //    //#region Mapping
        //    //new KeyValuePair<string, string>("100", "Continue"),
        //    //new KeyValuePair<string, string>("101", "Switching Protocols"),
        //    //new KeyValuePair<string, string>("200", "OK"),
        //    //#endregion
        //    //};



        //    //CreateMappingType(1, "HttpStatusCodes");
        //    //CreateMappingType(2, "CountryCodes");
        //    //CreateMappingType(3, "EncodedCharacterCodes");
        //    //CreateMappingType(4, "CurrencyCodes");

        //    //ReadXml("CurrencyMap.xml");
        //    //CreateMappings(_encodingCharacterMap, 4);
        //    //GetMappings(4);
        //    //ClearMappings();
        //}


        /// <summary>
        /// Gets the character map.
        /// </summary>
        /// <returns></returns>
        public List<KeyValuePair<string, string>> GetCharacterMap(int mappingTypeId)
        {
            var savedMappings = GetMappings(mappingTypeId);
            return savedMappings.Select(m => new KeyValuePair<string, string>(m.Key, m.Value)).ToList();
        }


        ///// <summary>
        ///// Reads the XML.
        ///// </summary>
        ///// <param name="path">The path.</param>
        //public void ReadXml(string path)
        //{
        //    var serializer = new DataContractSerializer((typeof(List<KeyValuePair<string, string>>)));
        //    _encodingCharacterMap = serializer.ReadObject(XmlReader.Create(path)) as List<KeyValuePair<string, string>>;
        //}

        ///// <summary>
        ///// Writes the XML.
        ///// </summary>
        //public void WriteXml()
        //{
        //    var dataContractSerializer = new DataContractSerializer(typeof(List<KeyValuePair<string, string>>));
        //    using (XmlWriter writer = XmlWriter.Create((_path)))
        //    {
        //        dataContractSerializer.WriteObject(writer, GetCharacterMap());
        //    }
        //}


        //entity framework 

        /// <summary>
        /// Creates the type of the mapping.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="mappingTypeName">Name of the mapping type.</param>
        public void CreateMappingType(int id, string mappingTypeName)
        {
            using (var context = new MappingModelContainer())
            {
                context.AddToMappingType(MappingType.CreateMappingType(id, mappingTypeName));
                context.SaveChanges();
            }
        }

        public List<MappingType> GetMappingTypes()
        {
            using (var context = new MappingModelContainer())
            {
                return (from c in context.MappingType
                             select c).ToList();
            }
        }


        /// <summary>
        /// get all mappings
        /// </summary>
        /// <returns></returns>
        public List<Mapping> GetMappings(int mappingTypeId)
        {
            using (var context = new MappingModelContainer())
            {
                List<Mapping> res = (from c in context.Mapping
                                     where c.MappingTypeId == mappingTypeId
                                     select c).ToList();
                return res;
            }
        }


        /// <summary>
        /// create a mapping
        /// </summary>
        public void CreateMappings(List<KeyValuePair<string, string>> keyvaluePairs, int mappingTypeId)
        {
            using (var context = new MappingModelContainer())
            {
                var lastMappingId = GetLastMappingId();

                foreach (var keyValuePair in keyvaluePairs)
                {
                    var m = Mapping.CreateMapping(++lastMappingId, keyValuePair.Key, keyValuePair.Value, mappingTypeId);
                    context.AddToMapping(m);
                    context.SaveChanges();
                }
            }
        }


        /// <summary>
        /// Clears all Mappings from database
        /// </summary>
        private void ClearMappings(int mappingTypeId)
        {
            using (var context = new MappingModelContainer())
            {
                foreach (Mapping map in GetMappings(mappingTypeId))
                {
                    Mapping mappings = CqMappingById.Invoke(context, map.ID);
                    context.Mapping.DeleteObject(mappings);
                    context.SaveChanges();
                }
            }

        }


        /// <summary>
        /// Gets the last mapping id.
        /// TODO: Get once this method and cache this
        /// </summary>
        /// <returns></returns>
        private int GetLastMappingId()
        {
            using (var context = new MappingModelContainer())
            {
                var result = (from c in context.Mapping
                              select c).OrderByDescending(m => m.ID).FirstOrDefault();

                return result == null ? 0 : result.ID;
            }
        }

        /// <summary>
        /// Gets the compiledQuery for mapping by id.
        /// </summary>
        static Func<MappingModelContainer, int, Mapping> _cqMappingById;
        static Func<MappingModelContainer, int, Mapping> CqMappingById
        {
            get
            {
                if (_cqMappingById == null)
                    _cqMappingById = CompiledQuery.Compile<MappingModelContainer, int, Mapping>(
                        (context, id) => context.Mapping.FirstOrDefault(m => m.ID == id));

                return _cqMappingById;
            }
        }


        /// <summary>
        /// Gets the compiledQuery for mappingtype by id.
        /// </summary>
        static Func<MappingModelContainer, int, MappingType> _cqMappingTypeById;
        static Func<MappingModelContainer, int, MappingType> CqMappingTypeById
        {
            get
            {
                if (_cqMappingTypeById == null)
                    _cqMappingTypeById = CompiledQuery.Compile<MappingModelContainer, int, MappingType>(
                        (context, id) => context.MappingType.FirstOrDefault(m => m.ID == id));

                return _cqMappingTypeById;
            }
        }



    }
}