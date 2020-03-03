using System;
using System.Collections.Generic;
using System.Text;

namespace ConanTheCSharpian.Core.Characters
{
    /// <summary>
    /// An Interface for classes that are supposed to control Character actions
    /// 
    /// NOTE: the implementing Classes could be defined even OUTSIDE our Core library:, but 
    ///       AS LONG AS THEY IMPLEMENT THE ICharacterController INTERFACE THEY CAN BE USED FROM THERE AS WELL.
    ///       This allows us to re-use our Core library for other Projects (IE: WebApplication) as long as they
    ///       provide their own implementation for a ICharacterController.
    /// </summary>
    public interface ICharacterController // We need to declare it public if it want it to be accessible from other PROJECTS as well (such as ConanTheCSharpian.ConsoleApplication)
    {
        void PerformNextAction(Character characterInTurn);
    }

    // HACK: additional information about Interfaces: https://medium.com/better-programming/code-against-interfaces-not-implementations-37b30e7ab992
    /*
     * 
        Interfaces are an abstract definition of functionality.

        An interface declaration defines a set of properties and methods that you can use for a specific purpose. 
        Interfaces declare and require no particular implementation for that purpose.
        They define what a class can do and limit the exposure of a class to only those things defined by the interface.
        Of course, an interface must be implemented to be useful.
        And when you use an interface, you ultimately don’t care about how it is implemented;
        you just know that you can call the methods and properties on the interface and the functionality you need will be provided.

        Implementation hiding (i.e., abstraction) is one of the primary purposes of using interfaces.

     */
}
