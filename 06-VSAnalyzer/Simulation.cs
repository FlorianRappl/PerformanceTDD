using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 
 * (c) Florian Rappl, 2012-2013.
 * 
 * This work is a demonstration for training purposes and may be used freely for private purposes.
 * Usage for business training / workshops is prohibited without explicit permission from the author.
 * 
 */

namespace Performance
{
    class Simulation
    {
        #region Constants

        const int LENGTH = 1000;
        const double TEMP = 2.0;  /* in units of interaction and k_B */
        const int WARM = 10;
        const int MCS = 100000;

        #endregion

        #region Members

        Rand ran;
        int[] spin;
        int[] nbr1;
        int[] nbr2;

        #endregion

        #region ctor

        public Simulation()
        {
            ran = new Rand();
            spin = new int[LENGTH];
            nbr1 = new int[LENGTH];
            nbr2 = new int[LENGTH];
        }

        #endregion

        #region Properties

        public Double EnergyPerSpin
        {
            get;
            private set;
        }

        public Double MagnetizationPerSpin
        {
            get;
            private set;
        }

        #endregion

        #region Methods

        public void Run()
        {
            var norm = 1.0 / ((MCS - WARM) * LENGTH);
            var big_energy = 0;
            var big_mag = 0;
            var itime = 0;
            var energy_analytic = -1.0 * Math.Tanh(1.0 / TEMP);

            /*  get started */
            Initialize();

            /* warm up system */
            for (int i = 1; i <= WARM; i++)
            {
                itime = i;
                MCMove();
            }

            /* do Monte Carlo steps */
            for (int i = (WARM + 1); i <= MCS; i++)
            {
                itime = i;
                MCMove();
                big_mag = big_mag + TotalMagnetization();
                big_energy = big_energy + TotalEnergy();
            }

            EnergyPerSpin = big_mag * norm;
            MagnetizationPerSpin = big_energy * norm;
        }

        #endregion

        #region Helpers

        void MCMove()
        {
            var flag = 0;
            var prob = Math.Exp(-4.0 / TEMP);

            for (int i = 0; i < LENGTH; i++)
            {
                var index = ran.Discrete(0, LENGTH);

                if ((spin[index] == spin[nbr1[index]]) && (spin[nbr1[index]] == spin[nbr2[index]]) && (ran.Next() > prob)) 
                    flag = 0; 
                else 
                    flag = 1;

                spin[index] = (1 - 2 * flag) * spin[index];
            }
        }

        int TotalMagnetization()
        {
            int foom = 0;

            for (int i = 0; i < LENGTH; i++)
                foom += spin[i];

            return foom;
        }

        int TotalEnergy()
        {
            int fooe = 0;

            for (int i = 0; i < LENGTH; i++)
                fooe -= spin[i] * spin[nbr2[i]];

            return fooe;
        }

        void Initialize()
        {
            for (int i = 0; i < LENGTH; i++)
            {
                spin[i] = 1;
                nbr1[i] = i - 1;
                nbr2[i] = i + 1;

                if (nbr1[i] == -1)
                    nbr1[i] = LENGTH - 1;

                if (nbr2[i] == LENGTH)
                    nbr2[i] = 0;
            }
        }

        #endregion
    }
}
