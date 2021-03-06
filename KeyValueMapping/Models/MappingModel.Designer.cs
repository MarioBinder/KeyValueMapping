﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Dieser Code wurde aus einer Vorlage generiert.
//
//    Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten Ihrer Anwendung.
//    Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]

namespace KeyValueMapping.Models
{
    #region Kontexte
    
    /// <summary>
    /// Keine Dokumentation für Metadaten verfügbar.
    /// </summary>
    public partial class MappingModelContainer : ObjectContext
    {
        #region Konstruktoren
    
        /// <summary>
        /// Initialisiert ein neues MappingModelContainer-Objekt mithilfe der in Abschnitt 'MappingModelContainer' der Anwendungskonfigurationsdatei gefundenen Verbindungszeichenfolge.
        /// </summary>
        public MappingModelContainer() : base("name=MappingModelContainer", "MappingModelContainer")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialisiert ein neues MappingModelContainer-Objekt.
        /// </summary>
        public MappingModelContainer(string connectionString) : base(connectionString, "MappingModelContainer")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialisiert ein neues MappingModelContainer-Objekt.
        /// </summary>
        public MappingModelContainer(EntityConnection connection) : base(connection, "MappingModelContainer")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partielle Methoden
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet-Eigenschaften
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        public ObjectSet<Mapping> Mapping
        {
            get
            {
                if ((_Mapping == null))
                {
                    _Mapping = base.CreateObjectSet<Mapping>("Mapping");
                }
                return _Mapping;
            }
        }
        private ObjectSet<Mapping> _Mapping;
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        public ObjectSet<MappingType> MappingType
        {
            get
            {
                if ((_MappingType == null))
                {
                    _MappingType = base.CreateObjectSet<MappingType>("MappingType");
                }
                return _MappingType;
            }
        }
        private ObjectSet<MappingType> _MappingType;

        #endregion
        #region AddTo-Methoden
    
        /// <summary>
        /// Veraltete Methode zum Hinzufügen eines neuen Objekts zum EntitySet 'Mapping'. Verwenden Sie stattdessen die Methode '.Add' der zugeordneten Eigenschaft 'ObjectSet&lt;T&gt;'.
        /// </summary>
        public void AddToMapping(Mapping mapping)
        {
            base.AddObject("Mapping", mapping);
        }
    
        /// <summary>
        /// Veraltete Methode zum Hinzufügen eines neuen Objekts zum EntitySet 'MappingType'. Verwenden Sie stattdessen die Methode '.Add' der zugeordneten Eigenschaft 'ObjectSet&lt;T&gt;'.
        /// </summary>
        public void AddToMappingType(MappingType mappingType)
        {
            base.AddObject("MappingType", mappingType);
        }

        #endregion
    }
    

    #endregion
    
    #region Entitäten
    
    /// <summary>
    /// Keine Dokumentation für Metadaten verfügbar.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="MappingModel", Name="Mapping")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Mapping : EntityObject
    {
        #region Factory-Methode
    
        /// <summary>
        /// Erstellt ein neues Mapping-Objekt.
        /// </summary>
        /// <param name="id">Anfangswert der Eigenschaft ID.</param>
        /// <param name="key">Anfangswert der Eigenschaft Key.</param>
        /// <param name="value">Anfangswert der Eigenschaft Value.</param>
        /// <param name="mappingTypeId">Anfangswert der Eigenschaft MappingTypeId.</param>
        public static Mapping CreateMapping(global::System.Int32 id, global::System.String key, global::System.String value, global::System.Int32 mappingTypeId)
        {
            Mapping mapping = new Mapping();
            mapping.ID = id;
            mapping.Key = key;
            mapping.Value = value;
            mapping.MappingTypeId = mappingTypeId;
            return mapping;
        }

        #endregion
        #region Primitive Eigenschaften
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (_ID != value)
                {
                    OnIDChanging(value);
                    ReportPropertyChanging("ID");
                    _ID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID");
                    OnIDChanged();
                }
            }
        }
        private global::System.Int32 _ID;
        partial void OnIDChanging(global::System.Int32 value);
        partial void OnIDChanged();
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Key
        {
            get
            {
                return _Key;
            }
            set
            {
                OnKeyChanging(value);
                ReportPropertyChanging("Key");
                _Key = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Key");
                OnKeyChanged();
            }
        }
        private global::System.String _Key;
        partial void OnKeyChanging(global::System.String value);
        partial void OnKeyChanged();
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Value
        {
            get
            {
                return _Value;
            }
            set
            {
                OnValueChanging(value);
                ReportPropertyChanging("Value");
                _Value = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Value");
                OnValueChanged();
            }
        }
        private global::System.String _Value;
        partial void OnValueChanging(global::System.String value);
        partial void OnValueChanged();
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 MappingTypeId
        {
            get
            {
                return _MappingTypeId;
            }
            set
            {
                OnMappingTypeIdChanging(value);
                ReportPropertyChanging("MappingTypeId");
                _MappingTypeId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("MappingTypeId");
                OnMappingTypeIdChanged();
            }
        }
        private global::System.Int32 _MappingTypeId;
        partial void OnMappingTypeIdChanging(global::System.Int32 value);
        partial void OnMappingTypeIdChanged();

        #endregion
    
    }
    
    /// <summary>
    /// Keine Dokumentation für Metadaten verfügbar.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="MappingModel", Name="MappingType")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class MappingType : EntityObject
    {
        #region Factory-Methode
    
        /// <summary>
        /// Erstellt ein neues MappingType-Objekt.
        /// </summary>
        /// <param name="id">Anfangswert der Eigenschaft ID.</param>
        /// <param name="typeName">Anfangswert der Eigenschaft TypeName.</param>
        public static MappingType CreateMappingType(global::System.Int32 id, global::System.String typeName)
        {
            MappingType mappingType = new MappingType();
            mappingType.ID = id;
            mappingType.TypeName = typeName;
            return mappingType;
        }

        #endregion
        #region Primitive Eigenschaften
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (_ID != value)
                {
                    OnIDChanging(value);
                    ReportPropertyChanging("ID");
                    _ID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID");
                    OnIDChanged();
                }
            }
        }
        private global::System.Int32 _ID;
        partial void OnIDChanging(global::System.Int32 value);
        partial void OnIDChanged();
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String TypeName
        {
            get
            {
                return _TypeName;
            }
            set
            {
                OnTypeNameChanging(value);
                ReportPropertyChanging("TypeName");
                _TypeName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("TypeName");
                OnTypeNameChanged();
            }
        }
        private global::System.String _TypeName;
        partial void OnTypeNameChanging(global::System.String value);
        partial void OnTypeNameChanged();

        #endregion
    
    }

    #endregion
    
}
