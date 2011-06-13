using System;
using System.Collections.Generic;
using System.Windows.Controls;
using MPUrlEncoding.Models;

namespace MPUrlEncoding.ViewModels
{
    public class MainViewModel : ViewModelBase<MainViewModel>
    {
        public List<KeyValuePair<string, string>> ValuePairs { get; set; }
        public List<AutoCompleteFilterMode> AutoCompleteFilters { get; set; }
       
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
        
        public MainViewModel()
        {
            SetAutoCompleteFilters();
            GetAutoCompleteBoxItems();
        }
        
        private void SetAutoCompleteFilters()
        {
            var values = Enum.GetValues((typeof(AutoCompleteFilterMode)));

            AutoCompleteFilters = new List<AutoCompleteFilterMode>();
            foreach (AutoCompleteFilterMode value in values)
            {
                AutoCompleteFilters.Add(value);
            }
        }

        private void GetAutoCompleteBoxItems()
        {
            string map = "EncodedCharacterMap.xml";
            var mapping = new Mapping(map);

            //mapping.WriteXml();
            mapping.ReadXml(map);
            ValuePairs = mapping.GetCharacterMap();
        }


    }
}
