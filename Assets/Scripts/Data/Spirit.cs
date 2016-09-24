namespace ExtrasensoryGame.Data
{
    using SpiritDialogs;

    public class Spirit
    {
        private SpiritDialog[] _avaliableDialogs;

        public Spirit(SpiritDialog[] avaliableDialogs)
        {
            this._avaliableDialogs = avaliableDialogs;
        }
    }
}