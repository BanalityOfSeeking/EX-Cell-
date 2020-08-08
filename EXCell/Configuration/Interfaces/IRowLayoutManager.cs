namespace EXCell.ConfigurationStore
{
    public interface IRowLayoutManager
    {
        int Column { get; set; }
        int Row { get; set; }
        ICellConfiguration Configs { get; }

        sealed bool Equals(object obj)
        {
            return obj is IRowLayoutManager manager &&
                    Row == manager.Row &&
                    Column == manager.Column;
        }

        sealed int GetHashCode()
        {
            int hashCode = 240067226;
            hashCode = (hashCode * -1521134295) + Row.GetHashCode();
            hashCode = (hashCode * -1521134295) + Column.GetHashCode();
            return hashCode;
        }

        sealed int RequestColumnId(ICellConfiguration configs, bool IsConfigComplete = false)
        {
            if (IsConfigComplete)
            {
                configs.ConfigurationComplete();
                return Column;
            }
            return Column++;
        }

        sealed int RequestRowId(ICellConfiguration configs)
        {
            if (configs.IsConfigurationComplete)
            {
                return Row++;
            }
            return 0;
        }
    }
}