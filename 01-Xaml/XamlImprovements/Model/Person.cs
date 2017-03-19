namespace XamlImprovements.Model
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsMvp { get; set; }
        public string GetFullDescription(string name, string surname, bool isMvp)
        {
            if (isMvp)
            {
                return $"{name} {surname} is a Microsoft MVP";
            }
            else
            {
                return $"{name} {surname} isn't a Microsoft MVP";
            }
        }
    }
}
