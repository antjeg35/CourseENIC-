namespace TP1Module6EntityFrameworkBODojo
{
    public class Samourai
    {
        public int Id { get; set; }
        public int Force { get; set; }
        public string Nom { get; set; }
        public virtual Arme Arme { get; set; }
    }
}
