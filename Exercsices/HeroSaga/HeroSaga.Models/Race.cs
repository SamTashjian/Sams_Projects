using System.Collections.Generic;

namespace HeroSaga.Models
{
    public class Race
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Character> Characters { get; set; }
    }
}