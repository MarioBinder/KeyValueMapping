using System;
using System.Collections.Generic;
using System.Windows.Controls;
using MPUrlEncoding.Models;

namespace MPUrlEncoding.ViewModels
{
    public class MainViewModel : ViewModelBase<MainViewModel>
    {
        public List<AutoCompleteFilterMode> AutoCompleteFilters { get; set; }

        private List<KeyValuePair<string, string>> _valuePairs;
        public List<KeyValuePair<string, string>> ValuePairs
        {
            get { return _valuePairs; }
            set { _valuePairs = value; RaisePropertyChanged(m => m.ValuePairs); }
        }

        private AutoCompleteFilterMode _selectedFilterMode;
        public AutoCompleteFilterMode SelectedFilterMode
        {
            get
            {
                return _selectedFilterMode;
            }

            set
            {
                _selectedFilterMode = value;
                RaisePropertyChanged(m => m.SelectedFilterMode);
            }
        }

        private List<MappingType> _mappingTypes;
        public List<MappingType> MappingTypes
        {
            get { return _mappingTypes; }
            set { _mappingTypes = value; RaisePropertyChanged(m => m.MappingTypes); }
        }

        private MappingType _selectedMappingType;
        public MappingType SelectedMappingType
        {
            get { return _selectedMappingType; }
            set { _selectedMappingType = value; GetAutoCompleteBoxItems(_selectedMappingType); }
        }


        public MainViewModel()
        {
            SetAutoCompleteFilters();
            GetMappingTypes();

            //first select TODO - configuration or last input
            SelectedFilterMode = AutoCompleteFilterMode.Contains;
           
        }

        private void GetMappingTypes()
        {
            MappingTypes = new List<MappingType>();
            var mappingManagement = new MappingManagement();

            MappingTypes = mappingManagement.GetMappingTypes();
        }

        private void SetAutoCompleteFilters()
        {
            Array values = Enum.GetValues((typeof(AutoCompleteFilterMode)));

            AutoCompleteFilters = new List<AutoCompleteFilterMode>();
            foreach (AutoCompleteFilterMode value in values)
            {
                AutoCompleteFilters.Add(value);
            }
        }

        private void GetAutoCompleteBoxItems(MappingType mappingType)
        {
            var mapping = new MappingManagement();

            if (mappingType != null)
                ValuePairs = mapping.GetCharacterMap(mappingType.ID);
        }

    }
}
