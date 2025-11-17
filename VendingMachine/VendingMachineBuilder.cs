namespace VendingMachine
{
    public class VendingMachineBuilder
    {
        private int _cantidadChips = 0;
        private int _cantidadCola = 0;
        private int _cantidadCandy = 0;
        private int _cantidadNickel = 0;
        private int _cantidadDime = 0;
        private int _cantidadQuarter = 0;

        public VendingMachineBuilder ConChips(int cantidad)
        {
            _cantidadChips = cantidad;
            return this;
        }

        public VendingMachineBuilder ConCola(int cantidad)
        {
            _cantidadCola = cantidad;
            return this;
        }

        public VendingMachineBuilder ConCandy(int cantidad)
        {
            _cantidadCandy = cantidad;
            return this;
        }

        public VendingMachineBuilder ConNickel(int cantidad)
        {
            _cantidadNickel = cantidad;
            return this;
        }

        public VendingMachineBuilder ConDime(int cantidad)
        {
            _cantidadDime = cantidad;
            return this;
        }

        public VendingMachineBuilder ConQuarter(int cantidad)
        {
            _cantidadQuarter = cantidad;
            return this;
        }

        public VendingMachine Build()
        {
            return new VendingMachine(
                cantidadChips: _cantidadChips,
                cantidadCola: _cantidadCola,
                cantidadCandy: _cantidadCandy,
                cantidadNickel: _cantidadNickel,
                cantidadDime: _cantidadDime,
                cantidadQuarter: _cantidadQuarter
            );
        }
    }
}