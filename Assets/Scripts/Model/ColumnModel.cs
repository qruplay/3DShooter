using Interface;

namespace Model
{
    public class ColumnModel : BaseModel, ISelectable
    {
        public string GetMessage()
        {
            return Name;
        }
    }
}