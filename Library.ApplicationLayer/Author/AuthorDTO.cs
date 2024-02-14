namespace Library.ApplicationLayer.Author
{
    public class AuthorDTO
    {
        public AuthorDTO(string name)
        {
            Gaurd(name);
            Name = name;
        }
        public string Name { get; set; }
        public void Gaurd(string name)
        {
            if (name == "")
            {
                throw new InvalidDataException("name couldn't be null");
            }
            else if (name.Length > 80)
            {
                throw new InvalidDataException("Length of Name Should be less than 80 char");
            }
        }
    }
}