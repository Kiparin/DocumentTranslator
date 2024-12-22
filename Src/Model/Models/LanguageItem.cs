using System.Collections.ObjectModel;

using Model.Enums;

namespace Model.Model
{
    public class LanguageItem
    {
        public int Id { get; set; }

        public Languages Languages { get; set; }

        public string Name
        {
            get
            {
                return Languages.ToString();
            }
        }

        public static readonly ObservableCollection<LanguageItem> GetLanguageItem = new ObservableCollection<LanguageItem>
                {
                    new LanguageItem { Id = 1, Languages = Languages.Русский },
                    new LanguageItem { Id = 2, Languages = Languages.English }
                };
    }
}