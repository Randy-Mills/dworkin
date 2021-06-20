using System;
using System.Linq;
using Dworkin.Interfaces;
using Dworkin.Models;

namespace Dworkin.Tables.WildMagic
{
    public class EldritchMagic : ITable
    {
        private Percentile[] _table = {
            new Percentile(0,2,"You gain the ability to consume your own fingernails as if they were the fruit of a goodberry spell."),
            new Percentile(2,2,"Your hair turns bone white."),
            new Percentile(4,2,"Over the next 2d6 days you grow mouths on the palms of each hand. A remove curse spell can end this effect."),
            new Percentile(6,2,"For the next 2d6 days, horrid pustules grow on your face giving you disadvantage on all Charisma checks."),
            new Percentile(8,2,"For the next hour, you can comprehend all languages but can only speak Abyssal."),
            new Percentile(10,2,"Summon eight swarms of CR 1/4 rats."),
            new Percentile(12,2,"For the next minute, all non-magic organic things you touch rot, metal rusts, and food spoils."),
            new Percentile(14,2,"You cast animate dead on the nearest corpse within a mile."),
            new Percentile(16,2,"You see all reflections of your self as if you were a rotted corpse. A remove curse spell can end this effect."),
            new Percentile(18,2,"You become suddenly aware of the horrible truth... if you tear out and consume your left eye you will regain all expended sorcery points."),
            new Percentile(20,2,"You cast inflict wounds on yourself. The next spell you cast deals maximum damage."),
            new Percentile(22,2,"For 1d4 rounds maggots fall from your mouth with you try to speak, preventing you from talking."),
            new Percentile(24,2,"You cast arms of Hadar as a 1st level spell. You may increase its level and take 1d4 necrotic damage for each rank you increase it."),
            new Percentile(26,2,"You are chilled and your teeth chatter uncontrollably, giving you disadvantage on concentration next hour or until warmed up."),
            new Percentile(28,2,"For an hour, your skin grows dry and scaly. Your AC cannot be below 16 for this time."),
            new Percentile(30,2,"You cast misty step bursting into a flock of ravens that reform at the spell's chosen location."),
            new Percentile(32,2,"You cast false life on yourself."),
            new Percentile(34,2,"For the next minute your face becomes pale, your lips blue and your breath white. You may cast ray of frost as a bonus action."),
            new Percentile(36,2,"Over the next 2d6 days your ears, nose and lips rot off, giving you disadvantage to persuasion checks and advantage to intimidate checks."),
            new Percentile(38,2,"The next time you sleep or meditate, you are afflicted with horrible nightmares or visions and take 1d6 psychic damage."),
            new Percentile(40,2,"You sprout a twisted and useless malformed arm from your side."),
            new Percentile(42,2,"You cast grasping vine, it summons a tentacle instead."),
            new Percentile(44,2,"Over the next 2d6 days you grow a stubby, fleshy vestigial tail and wings. You can hack them off for 3d6 damage."),
            new Percentile(46,2,"For the next minute, you may choose to cast spells with casting times of 1 action as if their casting time were 1 bonus action. If you do so you bleed from your nose and take 1d4 psychic damage."),
            new Percentile(48,2,"Over the next 2d6 days, your left arm becomes gelatinous and flexible until it becomes a tentacle."),
            new Percentile(50,2,"You and all creatures within 30' are affected by fleshrot as if by the contagion spell."),
            new Percentile(52,2,"Over the next 2d6 days you grow a face on the back of your head that is a warped and useless copy of your own."),
            new Percentile(54,2,"For the next 2d6 days you smell like rotting meat. The smell worsens and fades over this time."),
            new Percentile(56,2,"Your touch becomes painful to others, like the sting of nettles."),
            new Percentile(58,2,"Worms erupt from your flesh and knit it together. You gain 2d10 temporary hit points."),
            new Percentile(60,2,"Your skin becomes semi-translucent making your veins and muscles visible."),
            new Percentile(62,2,"For 1d4 rounds your eyes go milk white and you are blind."),
            new Percentile(64,2,"You become frightened for 1d4 rounds."),
            new Percentile(66,2,"A ghoul under your control rises from the earth. It ceases to be controlled by you in 1d4 hours."),
            new Percentile(68,2,"Your teeth grow longer, sharper, and more canine. You pant when you breath. A remove curse spell can end this effect."),
            new Percentile(70,2,"For the next hour you cast speak with dead on all corpses you touch."),
            new Percentile(72,2,"All creatures in a 30' cone in front of you are frightened. Your eyes become black for a round."),
            new Percentile(74,2,"You cast dissonant whispers on yourself."),
            new Percentile(76,2,"For the next 2d6 days you feel compelled to hack up the body of any creature you kill. Take 1d4 psychic damage each time you kill a creature and do not do this within ten minutes."),
            new Percentile(78,2,"For the next minute, each time you lose health, a CR 1/4 swarm of spiders crawls from the wound under your control."),
            new Percentile(80,2,"You no longer age, require food, drink, nor air."),
            new Percentile(82,2,"For an hour your tongue becomes a centipede. You may speak all languages."),
            new Percentile(84,2,"You cast detect thoughts. This lasts for one hour and you do not need to concentrate to maintain the effect. Each time you use your action to focus it, take 1d4 psychic damage."),
            new Percentile(86,2,"You rapidly gain 2d6 pounds and an equal number of temporary hit points."),
            new Percentile(88,2,"You cast darkness centered on yourself."),
            new Percentile(90,2,"You cast hunger of Hadar centered on yourself. You automatically succeed on the concentration check and cannot choose to end it."),
            new Percentile(92,2,"You deal 1d10 necrotic damage to all creatures within 30' of you and gain the much health."),
            new Percentile(94,2,"The next time you are damaged by necrotic damage, you are instead of healed that much health."),
            new Percentile(96,2,"You age 1d4 years and regain all expended sorcery points."),
            new Percentile(98,2,"Reroll, you may spend 1d4 health to move one space up or down this table. You may pay this multiple times to move multiple spaces.")
        };

        public EldritchMagic()
        {
            Table = _table;
            Max = _table[_table.Length-1].min+(_table[_table.Length-1].max-1);
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