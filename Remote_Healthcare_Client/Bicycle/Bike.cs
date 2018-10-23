using System;

namespace Remote_Healthcare_Client.Bicycle
{
    public abstract class Bike
    {

        public abstract void SetPower(int speed);           // PW+x, x tussen 25 en 400 (VS+x?)
        public abstract void SetDistance(int hectometers);  // PD+x
        public abstract void SetEnergy(int kiloJoules);     // PE+x
        public abstract void SetTime(int seconds);          // PT+x
        public abstract void SetTime(DateTime time);        // PT+x

        public abstract string GetID();                     // ID
        public abstract void GetVariables();              // ST

        public abstract void Reset();                       // RS
        protected abstract void StartEdit();                // CD / CM

        public abstract void SetCountdownMode();    // CM
        public abstract void SetCountupMode();      // CD



        // TODO: New methods like max/avg/current speed?

    }
}
