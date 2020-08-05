using System;
using System.Linq;
using Generator.Models;
using Toolkit.Generator;

namespace Generator.Tables.WildMagic
{
    public class EldritchMagic : ITable
    {
        private Percentile[] _table = {
            new Percentile(0,1,"You gain the ability to consume your own fingernails as if they were the fruit of a goodberry spell."),
            new Percentile(2,3,"Your hair turns bone white."),
            new Percentile(4,5,"Over the next 2d6 days you grow mouths on the palms of each hand. A remove curse spell can end this effect."),
            new Percentile(6,7,"For the next 2d6 days, horrid pustules grow on your face giving you disadvantage on all Charisma checks."),
            new Percentile(8,9,"For the next hour, you can comprehend all languages but can only speak Abyssal."),
            new Percentile(10,11,"Summon eight swarms of CR 1/4 rats."),
            new Percentile(12,13,"For the next minute, all non-magic organic things you touch rot, metal rusts, and food spoils."),
            new Percentile(14,15,"You cast animate dead on the nearest corpse within a mile."),
            new Percentile(16,17,"You see all reflections of your self as if you were a rotted corpse. A remove curse spell can end this effect."),
            new Percentile(18,19,"You become suddenly aware of the horrible truth... if you tear out and consume your left eye you will regain all expended sorcery points."),
            new Percentile(20,21,"You cast inflict wounds on yourself. The next spell you cast deals maximum damage."),
            new Percentile(22,23,"For 1d4 rounds maggots fall from your mouth with you try to speak, preventing you from talking."),
            new Percentile(24,25,"You cast arms of Hadar as a 1st level spell. You may increase its level and take 1d4 necrotic damage for each rank you increase it."),
            new Percentile(26,27,"You are chilled and your teeth chatter uncontrollably, giving you disadvantage on concentration next hour or until warmed up."),
            new Percentile(28,29,"For an hour, your skin grows dry and scaly. Your AC cannot be below 16 for this time."),
            new Percentile(30,31,"You cast misty step bursting into a flock of ravens that reform at the spell's chosen location."),
            new Percentile(32,33,"You cast false life on yourself."),
            new Percentile(34,35,"For the next minute your face becomes pale, your lips blue and your breath white. You may cast ray of frost as a bonus action."),
            new Percentile(36,37,"Over the next 2d6 days your ears, nose and lips rot off, giving you disadvantage to persuasion checks and advantage to intimidate checks."),
            new Percentile(38,39,"The next time you sleep or meditate, you are afflicted with horrible nightmares or visions and take 1d6 psychic damage."),
            new Percentile(40,41,"You sprout a twisted and useless malformed arm from your side."),
            new Percentile(42,43,"You cast grasping vine, it summons a tentacle instead."),
            new Percentile(44,45,"Over the next 2d6 days you grow a stubby, fleshy vestigial tail and wings. You can hack them off for 3d6 damage."),
            new Percentile(46,47,"For the next minute, you may choose to cast spells with casting times of 1 action as if their casting time were 1 bonus action. If you do so you bleed from your nose and take 1d4 psychic damage."),
            new Percentile(48,49,"Over the next 2d6 days, your left arm becomes gelatinous and flexible until it becomes a tentacle."),
            new Percentile(50,51,"You and all creatures within 30' are affected by fleshrot as if by the contagion spell."),
            new Percentile(52,53,"Over the next 2d6 days you grow a face on the back of your head that is a warped and useless copy of your own."),
            new Percentile(54,55,"For the next 2d6 days you smell like rotting meat. The smell worsens and fades over this time."),
            new Percentile(56,57,"Your touch becomes painful to others, like the sting of nettles."),
            new Percentile(58,59,"Worms erupt from your flesh and knit it together. You gain 2d10 temporary hit points."),
            new Percentile(60,61,"Your skin becomes semi-translucent making your veins and muscles visible."),
            new Percentile(62,63,"For 1d4 rounds your eyes go milk white and you are blind."),
            new Percentile(64,65,"You become frightened for 1d4 rounds."),
            new Percentile(66,67,"A ghoul under your control rises from the earth. It ceases to be controlled by you in 1d4 hours."),
            new Percentile(68,69,"Your teeth grow longer, sharper, and more canine. You pant when you breath. A remove curse spell can end this effect."),
            new Percentile(70,71,"For the next hour you cast speak with dead on all corpses you touch."),
            new Percentile(72,73,"All creatures in a 30' cone in front of you are frightened. Your eyes become black for a round."),
            new Percentile(74,75,"You cast dissonant whispers on yourself."),
            new Percentile(76,77,"For the next 2d6 days you feel compelled to hack up the body of any creature you kill. Take 1d4 psychic damage each time you kill a creature and do not do this within ten minutes."),
            new Percentile(78,79,"For the next minute, each time you lose health, a CR 1/4 swarm of spiders crawls from the wound under your control."),
            new Percentile(80,81,"You no longer age, require food, drink, nor air."),
            new Percentile(82,83,"For an hour your tongue becomes a centipede. You may speak all languages."),
            new Percentile(84,85,"You cast detect thoughts. This lasts for one hour and you do not need to concentrate to maintain the effect. Each time you use your action to focus it, take 1d4 psychic damage."),
            new Percentile(86,87,"You rapidly gain 2d6 pounds and an equal number of temporary hit points."),
            new Percentile(88,89,"You cast darkness centered on yourself."),
            new Percentile(90,91,"You cast hunger of Hadar centered on yourself. You automatically succeed on the concentration check and cannot choose to end it."),
            new Percentile(92,93,"You deal 1d10 necrotic damage to all creatures within 30' of you and gain the much health."),
            new Percentile(94,95,"The next time you are damaged by necrotic damage, you are instead of healed that much health."),
            new Percentile(96,97,"You age 1d4 years and regain all expended sorcery points."),
            new Percentile(98,99,"Reroll, you may spend 1d4 health to move one space up or down this table. You may pay this multiple times to move multiple spaces.")
        };

        public EldritchMagic()
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