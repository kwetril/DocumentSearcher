﻿using System;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchCore.TextProcessors.Interfaces;

namespace SearchCore.TextProcessors.Implementation
{
    public class RusStopWordsProvider : IStopWordsProvider
    {
        private static readonly ImmutableHashSet<string> RussianStopWords = ImmutableHashSet.CreateRange(
            new string[] {
                "а"
                ,"без"
                ,"более"
                ,"бы"
                ,"был"
                ,"была"
                ,"были"
                ,"было"
                ,"быть"
                ,"в"
                ,"вам"
                ,"вас"
                ,"весь"
                ,"во"
                ,"вот"
                ,"все"
                ,"всего"
                ,"всех"
                ,"вы"
                ,"где"
                ,"да"
                ,"даже"
                ,"для"
                ,"до"
                ,"его"
                ,"ее"
                ,"если"
                ,"есть"
                ,"еще"
                ,"же"
                ,"за"
                ,"здесь"
                ,"и"
                ,"из"
                ,"или"
                ,"им"
                ,"их"
                ,"к"
                ,"как"
                ,"ко"
                ,"когда"
                ,"кто"
                ,"ли"
                ,"либо"
                ,"мне"
                ,"может"
                ,"мы"
                ,"на"
                ,"надо"
                ,"наш"
                ,"не"
                ,"него"
                ,"нее"
                ,"нет"
                ,"ни"
                ,"них"
                ,"но"
                ,"ну"
                ,"о"
                ,"об"
                ,"однако"
                ,"он"
                ,"она"
                ,"они"
                ,"оно"
                ,"от"
                ,"очень"
                ,"по"
                ,"под"
                ,"при"
                ,"с"
                ,"со"
                ,"так"
                ,"также"
                ,"такой"
                ,"там"
                ,"те"
                ,"тем"
                ,"то"
                ,"того"
                ,"тоже"
                ,"той"
                ,"только"
                ,"том"
                ,"ты"
                ,"у"
                ,"уже"
                ,"хотя"
                ,"чего"
                ,"чей"
                ,"чем"
                ,"что"
                ,"чтобы"
                ,"чье"
                ,"чья"
                ,"эта"
                ,"эти"
                ,"это"
                ,"я"
                ,"они"
                ,"нас"
        });

        public ImmutableHashSet<string> GetStopWords()
        {
            return RussianStopWords;
        }
    }
}
