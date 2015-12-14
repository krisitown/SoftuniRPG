namespace Softuni_RPG.GameObjects.Items.Models
{
    public class Cuirass:EquipableItem
    {
        private const double defaultPower=0;
        private const double defaultDefence = 0;


        public Cuirass(string name, double power, double defence) : base(name, power, defence)
        {
        }
    }
}
