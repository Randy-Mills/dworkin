using System;
using System.Linq;
using Generator.Models;
using Toolkit.Generator;

namespace Generator.Tables.Bard
{
    public class InspirationBard : ITable
    {
        private Percentile[] _table = {
            new Percentile(0,1,"Accept responsibility for your life. Know that it is you who will get you where you want to go, no one else."),
            new Percentile(2,3,"Challenges are what make life interesting and overcoming them is what makes life meaningful."),
            new Percentile(4,5,"Its hard to wait around for something you know might never happen; but its harder to give up when you know its everything you want."),
            new Percentile(6,7,"Good things come to those who wait… greater things come to those who get off their ass and do anything to make it happen."),
            new Percentile(8,9,"The pain you feel today is the strength you feel tomorrow."),
            new Percentile(10,11,"Though no one can go back and make a brand new start, anyone can start from now and make a brand new ending."),
            new Percentile(12,13,"In this life, to earn you place you must fight for it!"),
            new Percentile(14,15,"Winners know when to quit. WHEN THEY WIN"),
            new Percentile(16,17,"These things we do that others may live."),
            new Percentile(18,19,"When cities burn and armies turn and flee in disarray, cowards will cry: 'Tis best to fly, and fight another day'. But warriors know in their marrow, When they die and fall, 'tis best to have fought and lost than not to have fought at all."),
            new Percentile(20,21,"You shall remember this victory forever"),
            new Percentile(22,23,"One day, your grandchildren shall tell the tale of this moment."),
            new Percentile(24,25,"You know your worth. It’s time to show it."),
            new Percentile(26,27,"Your success shall be all our success"),
            new Percentile(28,29,"Once, I made the decision to stand by your side, and I make that same choice again now."),
            new Percentile(30,31,"There is no greater companion than you."),
            new Percentile(32,33,"I am with you, from now until the end."),
            new Percentile(34,35,"I believe in you, not because you are infallible, but because you never give up"),
            new Percentile(36,37,"The sweetness of victory shall be like divine honey. Can you already taste it?"),
            new Percentile(38,39,"Let them cower before our fury!"),
            new Percentile(40,41,"Let them taste our might!"),
            new Percentile(42,43,"The fire burning within you is as great as a thousand suns!"),
            new Percentile(44,45,"Even the gods shall be awestruck by your deeds!"),
            new Percentile(46,47,"Hesitate not, my comrade! Onward!"),
            new Percentile(48,49,"This is the moment we change the course of history!"),
            new Percentile(50,51,"The heart of a lion beats within your chest!"),
            new Percentile(52,53,"Give up and die, or fight and live!"),
            new Percentile(54,55,"Do you fear this monster? You should. But even more, it should fear you!"),
            new Percentile(56,57,"Strike them down. We may not be in the right, but I don’t care. In battle, it doesn’t matter who’s right, it matters who’s left."),
            new Percentile(58,59,"This might end in disaster. But it also might end in us becoming the richest bastards in the world."),
            new Percentile(60,61,"Worry not, when I tell the tale of this moment one day, I’ll leave out how you would have failed spectacularly without my help."),
            new Percentile(62,63,"You’re always dressed to kill. You use magic the same way too."),
            new Percentile(64,65,"There is no sweeter music than the screams of our enemies. Now, go compose."),
            new Percentile(66,67,"If reckless shenanigans got us into this mess, then why can’t they get us out?"),
            new Percentile(68,69,"If it weren’t for foolish attempts at glory, then nothing would ever be accomplished."),
            new Percentile(70,71,"This is your opportunity to rise from the ashes and grab glory!"),
            new Percentile(72,73,"Where there is no peril in the fight, there is no glory in the triumph."),
            new Percentile(74,75,"In every battle there comes a time when both sides consider themselves beaten, then he who continues the attack wins."),
            new Percentile(76,77,"It is fatal to enter battle without the will to win it."),
            new Percentile(78,79,"The purpose of battle is to attain the greatest heights within your own limits!"),
            new Percentile(80,81,"Know thy self, know thy enemy. A thousand battles, a thousand victories."),
            new Percentile(82,83,"If you know the enemy and know yourself you need not fear the results of a hundred battles."),
            new Percentile(84,85,"No one cam win every battle, But no one should fall without a struggle!"),
            new Percentile(86,87,"Don't stop when you're tired, Stop when we have won!"),
            new Percentile(88,89,"If there is nothing but what we make in this world, friends…let us make it good."),
            new Percentile(90,91,"The future is worth it. All the pain. All the tears. The future is worth the fight."),
            new Percentile(92,93,"What happens when the unstoppable force meets the immovable object? They surrender."),
            new Percentile(94,95,"The real crime would be not to finish what we started."),
            new Percentile(96,97,"A true hero isn’t measured by the size of their strength, but by the size of their heart."),
            new Percentile(98,99,"There is a right and a wrong in the universe, and the distinction is not hard to make.")
        };

        public InspirationBard()
        {
            Table = _table;
            Max = _table[_table.Length-1].max;
        }

        public int Max { get; set; }
        public int Min { get; set; }
        public Percentile[] Table { get; set; }

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