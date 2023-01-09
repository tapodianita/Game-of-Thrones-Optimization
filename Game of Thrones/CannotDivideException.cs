using System;

namespace Game_of_Thrones
{
  class CannotDivideException : Exception {
    public CannotDivideException() : base("It cannot be optimized.") { }
  }
}
