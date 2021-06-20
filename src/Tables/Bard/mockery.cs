using System;
using System.Linq;
using Dworkin.Interfaces;
using Dworkin.Models;

namespace Dworkin.Tables.Bard
{
    public class MockeryBard : ITable
    {
        private Percentile[] _table = {
            new Percentile(0,1,"What smells worse than a goblin? Oh yeah, you!"),
            new Percentile(2,3,"Your mother takes up more tiles than a gelatinous cube!"),
            new Percentile(4,5,"You're going to make an excellent belt!"),
            new Percentile(6,7,"I'm glad you're tall...It means there's more of you I can despise!"),
            new Percentile(8,9,"I don't know whether to use charm person or hold monster!"),
            new Percentile(10,11,"You're the reason baby gnomes cry!"),
            new Percentile(12,13,"I swear, if you were any worse at this, you'd be doing our job for us!"),
            new Percentile(14,15,"On a scale of 1 - 10, you're proper screwed!"),
            new Percentile(16,17,"Your mother was a kobold and your father smelled of elderberry!"),
            new Percentile(18,19,"It gives me a headache just trying to think down to your level!"),
            new Percentile(20,21,"Some day you'll meet a doppelganger of yourself and be disappointed!"),
            new Percentile(22,23,"Are you always stupid, or are you making a special effort today!"),
            new Percentile(24,25,"You're lucky to be born beautiful, unlike me, who was born to be a big liar!"),
            new Percentile(26,27,"Your momma's so ugly, clerics try to turn her!"),
            new Percentile(28,29,"Your magic is as bad as your breath!"),
            new Percentile(30,31,"If ignorance is bliss, you must be the happiest person alive!"),
            new Percentile(32,33,"I could say you're as ugly as an ogre, but that would be an insult to ogres!"),
            new Percentile(34,35,"I would contact your mother about your death, but I don't speak goblin!"),
            new Percentile(36,37,"Your very existence is an insult to all!"),
            new Percentile(38,39,"You are maggot pie served from a dwarf's codpiece!"),
            new Percentile(40,41,"You look like a scab on a troll's wart!"),
            new Percentile(42,43,"No loot is worth having to look at you!"),
            new Percentile(44,45,"Would you like me to remove that curse? Oh my mistake, you were just born that way!"),
            new Percentile(46,47,"Your ugly face makes a good argument against raising the dead!"),
            new Percentile(48,49,"If your brain exploded, it wouldn't even mess up your hair!"),
            new Percentile(50,51,"Somewhere, Your depriving a village of it's idiot!"),
            new Percentile(52,53,"I heard what happened to your mother, it's not everyday your reflection kills you!"),
            new Percentile(54,55,"You're so stupid, if an illithid tried to eat your brain, it would starve to death!"),
            new Percentile(56,57,"What's that smell? I thought breath weapons were suppose to come out of your mouth!"),
            new Percentile(58,59,"Did your mother cast a darkness spell to feed you!"),
            new Percentile(60,61,"No wonder you're hiding behind cover, I'd hide too with a face like that!"),
            new Percentile(62,63,"Do you have a pen? Well you'd better get back to it before the farmer knows you are missing!"),
            new Percentile(64,65,"If I were you, I'd go and get my money back for that remove curse spell!"),
            new Percentile(66,67,"Very impressive, I think I'll hire you out for children's parties!"),
            new Percentile(68,69,"By looking at you, now I know what you get when you scrape out the bottom of the barrel!"),
            new Percentile(70,71,"I wish I still had that blindness spell, then I wouldn't have to endure that face anymore!"),
            new Percentile(72,73,"Tell me, did you run away from your parents, or did they run away from you!"),
            new Percentile(74,75,"They say every rose has its thorn, ain't that right, buttercup!"),
            new Percentile(76,77,"I'd say you were a worthy opponent, but I once fought a flumph wielding a dandelion!"),
            new Percentile(78,79,"How does it feel that you're not worthy of anyone casting a decent spell on you!"),
            new Percentile(80,81,"One day I'm going to make a ballad of this fight. Tell me your name, I hope it rhymes with horribly slaughtered!"),
            new Percentile(82,83,"Didn't there used to be like twice as many of you guys? What's up with that, huh!"),
            new Percentile(84,85,"Wait, wait, I just need to ask, what do you need us to put on your headstone!"),
            new Percentile(86,87,"You do know the pointy end is suppose to go in the other guy, right!"),
            new Percentile(88,89,"You're so pungent, sewers are masked by your stench."),
            new Percentile(90,91,"Congratulations! You're a failure."),
            new Percentile(92,93,"You look so bad you give others exhaustion automatically."),
            new Percentile(94,95,"A Wild Magic Sorcerer has better control than you!"),
            new Percentile(96,97,"The god of futile fights appreciates your devotion."),
            new Percentile(98,99,"Your mother is disappointed in you.")
        };

        public MockeryBard()
        {
            Table = _table;
            Max = _table[_table.Length-1].max;
        }

        public int Max { get; set; }
        public int Min { get; set; }
        public Percentile[] Table { get; set; }
        public Table MainTable { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Fetch(int position)
        {
            var response = "";
            foreach (Percentile element in Table)
            {
                if (Enumerable.Range(element.min,element.max).Contains(position))
                    response = element.value;
            }
            return response;
        }
    }
}