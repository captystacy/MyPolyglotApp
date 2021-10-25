﻿using MyPolyglotCore.Words;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyPolyglotCore
{
    public static class RandomWordHelper
    {
        private static readonly Random _random = new Random();
        private static readonly List<Word> _recognizableWords = Vocabulary.RecognizableVocabularies.ToList();

        public static Word GetRandomRecognizableWord()
        {
            return _recognizableWords[_random.Next(_recognizableWords.Count)];
        }

        public static Word GetRandomWord(this Type typeOfWord)
        {
            return GetRandomWord(Vocabulary.GetVocabulary(typeOfWord));
        }

        private static Word GetRandomWord(IEnumerable<Word> vocabulary)
        {
            var list = vocabulary.ToArray();
            return list[_random.Next(list.Length)];
        }

        public static Noun GetRandomNoun()
        {
            return (Noun)typeof(Noun).GetRandomWord();
        }

        public static Adjective GetRandomAdjective()
        {
            return (Adjective)typeof(Adjective).GetRandomWord();
        }

        public static Verb GetRandomIrregularVerb()
        {
            return (Verb)typeof(Verb).GetRandomWord();
        }

        public static PrimaryVerb GetRandomPrimaryVerb()
        {
            return (PrimaryVerb)typeof(PrimaryVerb).GetRandomWord();
        }

        public static ModalVerb GetRandomModalVerb()
        {
            return (ModalVerb)typeof(ModalVerb).GetRandomWord();
        }

        public static Determiner GetRandomDeterminer()
        {
            return (Determiner)typeof(Determiner).GetRandomWord();
        }

        public static Pronoun GetRandomReflexivePronoun()
        {
            return (Pronoun)GetRandomWord(Vocabulary.ReflexivePronouns);
        }

        public static Pronoun GetRandomPossessivePronoun()
        {
            return (Pronoun)GetRandomWord(Vocabulary.PossessivePronouns);
        }

        public static Pronoun GetRandomPossessiveAdjective()
        {
            return (Pronoun)GetRandomWord(Vocabulary.PossessiveAdjectives);
        }

        public static Pronoun GetRandomObjectPronoun()
        {
            return (Pronoun)GetRandomWord(Vocabulary.ObjectPronouns);
        }

        public static Pronoun GetRandomSubjectPronoun()
        {
            return (Pronoun)GetRandomWord(Vocabulary.SubjectPronouns);
        }

        public static Pronoun GetRandomDemonstrativePronoun()
        {
            return (Pronoun)GetRandomWord(Vocabulary.DemonstrativePronouns);
        }

        public static Preposition GetRandomPreposition()
        {
            return (Preposition)typeof(Preposition).GetRandomWord();
        }

        public static ComparisonAdjective GetRandomComparisonAdjective()
        {
            return (ComparisonAdjective)typeof(ComparisonAdjective).GetRandomWord();
        }

        public static Adverb GetRandomFrequencyAdverb()
        {
            return (Adverb)GetRandomWord(Vocabulary.FrequencyAdverbs);
        }

        public static Adverb GetRandomIntensifierAdverb()
        {
            return (Adverb)GetRandomWord(Vocabulary.IntensifierAdverbs);
        }

        public static Adverb GetRandomMannerAdverb()
        {
            return (Adverb)GetRandomWord(Vocabulary.MannerAdverbs);
        }

        public static Adverb GetRandomTellHowItHappendAdverb()
        {
            return (Adverb)GetRandomWord(Vocabulary.TellHowItHappenedAdverbs);
        }

        public static Adverb GetRandomTellTheExtentOfTheActionAdverb()
        {
            return (Adverb)GetRandomWord(Vocabulary.TellTheExtentOfTheActionAdverbs);
        }

        public static Adverb GetRandomTellWhenItHappendAdverb()
        {
            return (Adverb)GetRandomWord(Vocabulary.TellWhenItHappenedAdverbs);
        }

        public static Adverb GetRandomTellWhereItHappendAdverb()
        {
            return (Adverb)GetRandomWord(Vocabulary.TellWhereItHappenedAdverbs);
        }

        public static Compound GetRandomCompound()
        {
            return (Compound)typeof(Compound).GetRandomWord();
        }

        public static Compound GetRandomSomeCompound()
        {
            return (Compound)GetRandomWord(Vocabulary.SomeCompounds);
        }

        public static Compound GetRandomAnyCompound()
        {
            return (Compound)GetRandomWord(Vocabulary.AnyCompounds);
        }

        public static Compound GetRandomEveryCompound()
        {
            return (Compound)GetRandomWord(Vocabulary.EveryCompounds);
        }

        public static Compound GetRandomNoCompound()
        {
            return (Compound)GetRandomWord(Vocabulary.NoCompounds);
        }
    }
}
