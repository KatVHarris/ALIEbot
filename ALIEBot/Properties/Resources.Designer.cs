﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ALIEbot.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ALIEbot.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///   &quot;Characters&quot;: [
        ///    {
        ///      &quot;id&quot;:&quot;clarke&quot;,
        ///      &quot;Name&quot;: &quot;Clarke Griffin&quot;,
        ///      &quot;Description&quot;: &quot;Clarke is strong and determined. Her friends and family are her weakness. She is not as clever as Raven, though she is resourceful.&quot;,
        ///      &quot;Age&quot;: &quot;18&quot;,
        ///      &quot;LivingRelatvies&quot;: &quot;Dr. Abigail Griffin&quot;,
        ///      &quot;Kills&quot; : &quot;1000+&quot;,
        ///      &quot;Skills&quot;: &quot;Negotiation, Medical Knowledge&quot;,
        ///      &quot;Quote&quot;: &quot;Clarke Griffin&quot;,
        ///      &quot;DescriptionLink&quot;: &quot;...&quot;,
        ///      &quot;ImageLink&quot;: &quot;http://vignette4.wikia.nocookie.net/t [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string CharactersJSON {
            get {
                return ResourceManager.GetString("CharactersJSON", resourceCulture);
            }
        }
    }
}
