﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSOFAP.PSO.Interfaces;

namespace PSOFAP.PSO
{
    public class Particle<T> : ICloneable
    {
        public T Position { get; set; }
        public T Velocity { get; set; }
        public double Fitness { get; set; }
        public ParticleBest<T> PersonalBest { get; set; }

        public Particle()
        {
            Fitness = -1;
        }

        public Particle(T position)
        {
            Position = position;
            Fitness = -1;
        }

        public double Evaluate(IFitnessFunction<T> function)
        {
            double evalFitness = function.Evaluate(Position);
            if (IsPersonalBest(evalFitness))
            {
                SavePersonalBest(evalFitness);
            }
            Fitness = evalFitness;
            return evalFitness;
        }

        public void MoveTowards(T TargetPosition, IMoveFunction<T> function)
        {
            Position = function.MoveTowards(Position, TargetPosition);
        }

        private bool IsPersonalBest(double fitness)
        {
            if (PersonalBest == null)
            {
                return true;
            }
            else if (fitness <= PersonalBest.Fitness || PersonalBest.Fitness < 0)
            {
                return true;
            }
            return false;
        }

        private void SavePersonalBest(double cost)
        {
            PersonalBest = new ParticleBest<T>(Position, cost);
        }


        #region ICloneable Members

        public object Clone()
        {
            Particle<T> clone = new Particle<T>();
            clone.Position = (T)((ICloneable)Position).Clone();
            clone.Fitness = this.Fitness;
            return clone;

        }

        #endregion
    }
}
