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
    }
}
