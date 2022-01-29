using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMMTest
{
    public class AMM
    {
        public double coin;
        public double usd;

        public double k;

        public void AddLiquidity(double coin, double usd)
        {
            this.coin += coin;
            this.usd += usd;

            k = coin * usd;

        }


        public void SetLiquidity(double coin, double usd)
        {
            this.coin = coin;
            this.usd = usd;

            k = coin * usd;

        }

        public double CalAmountUSDWhenSwapByCoin(double c)
        {
            var cc = coin;
            cc += c;


            var afterUsd = k / cc;

            return usd - afterUsd;
        }

        public double CalAmountCoinWhenSwapByUSD(double u)
        {
            var cc = usd;
            cc += u;


            var afterCoin = k / cc;

            return coin - afterCoin;
        }

        internal void printState()
        {
            Console.WriteLine("현 상태 k " + k + " coin " + coin + "  usd " + usd);
        }
    }

    public class Program
    {


        public static void Main()
        {
            // Program p = new Program();
            //   p.AF(0,0,4);
            // Console.WriteLine("Count "+p.cnt);



            AMM a = new AMM();

            a.SetLiquidity(20000000, 20000);

            var swapCoinCount = 1;
            var swapUSDCount = 1;

            SellCoin(a, 1000000);
            a.printState();


            Console.WriteLine(swapCoinCount + "개의 코인을 교환할때 받는 USD " + a.CalAmountUSDWhenSwapByCoin(swapCoinCount));
            Console.WriteLine(swapUSDCount + "USD로 교환할떄 받는 Token " + a.CalAmountCoinWhenSwapByUSD(swapCoinCount));



        }



        private static void SellCoin(AMM a, int tokenCount)
        {
            var usd = a.CalAmountUSDWhenSwapByCoin(tokenCount); ;

            Console.WriteLine("token" + tokenCount + "를 + " + usd + "로 교환");
            a.usd -= usd;
            a.coin += tokenCount;
        }
        private static void BuyCoin(AMM a, int swapUSDCount)
        {
            var token = a.CalAmountCoinWhenSwapByUSD(swapUSDCount); ;

            Console.WriteLine("usd" + swapUSDCount + " 를  + " + token + "코인으로 교환");
            a.coin -= token;
            a.usd += swapUSDCount;
        }
    }
}
