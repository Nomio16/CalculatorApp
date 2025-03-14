using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorLibrary.Memories;

namespace CalculatorLibrary.General
{
    /*Тооны машины үндсэн классийг урьд үүсгэсэн abstract класс болон 
     * Interface ээсээ үүсгэнэ. Үр дүнд нь энэ класс нь 
     * Result гэсэн property тэй, нэмэх, хасах үйлдэл хийдэг байна.
     */
    public class RealCalculator : Calculator, IOperations
    {
        /// <summary>
        /// Memory хариуцсан property
        /// </summary>
        private Memory memo = new Memory(); // Initialize by default

        public Memory Memo
        {
            get => memo;
            set => memo = value ?? throw new ArgumentNullException(nameof(value), "Memory cannot be null");
        }


        /// <summary>
        /// Result-ийн утга дээр параметрээр авсан утгыг нэмнэ.
        /// </summary>
        /// <param name="value"></param>
        public void Add(double value)
        {
            Result += value;
        }

        /// <summary>
        /// Result-ийн утгаас параметрээр авсан утгыг хасна.
        /// </summary>
        /// <param name="value"></param>
        public void Subtract(double value)
        {
            Result -= value;
        }

        /// <summary>
        /// Result - ийн утга 0 болно.
        /// </summary>
        public override void Clear()
        {
            Result = 0;
        }

    }
}
