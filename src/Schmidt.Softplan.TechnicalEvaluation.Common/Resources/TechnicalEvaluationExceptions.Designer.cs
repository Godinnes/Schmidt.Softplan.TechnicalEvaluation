﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Schmidt.Softplan.TechnicalEvaluation.Common.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class TechnicalEvaluationExceptions {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal TechnicalEvaluationExceptions() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Schmidt.Softplan.TechnicalEvaluation.Common.Resources.TechnicalEvaluationExceptio" +
                            "ns", typeof(TechnicalEvaluationExceptions).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CPF não é válido..
        /// </summary>
        public static string CPFInvalidException {
            get {
                return ResourceManager.GetString("CPFInvalidException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Processo está com a situação finalizada..
        /// </summary>
        public static string ProcessoIsFinalizedSituacaoException {
            get {
                return ResourceManager.GetString("ProcessoIsFinalizedSituacaoException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Já existe um processo com este número..
        /// </summary>
        public static string ProcessoNumeroProcessoUnificadoAlreadyExistisException {
            get {
                return ResourceManager.GetString("ProcessoNumeroProcessoUnificadoAlreadyExistisException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Número de processo unificado precisa 20 catacteres..
        /// </summary>
        public static string ProcessoNumeroProcessoUnificadoLengthException {
            get {
                return ResourceManager.GetString("ProcessoNumeroProcessoUnificadoLengthException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Número de processo unificado é obrigatório..
        /// </summary>
        public static string ProcessoNumeroProcessoUnificadoNullException {
            get {
                return ResourceManager.GetString("ProcessoNumeroProcessoUnificadoNullException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Já existe um responsável com este CPF..
        /// </summary>
        public static string ResponsavelCPFAlreadyExistsException {
            get {
                return ResourceManager.GetString("ResponsavelCPFAlreadyExistsException", resourceCulture);
            }
        }
    }
}
