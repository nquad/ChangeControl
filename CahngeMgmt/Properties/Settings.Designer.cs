//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChangeMgmt.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=svru1mssql01;Initial Catalog=DayX;Persist Security Info=True;User ID=" +
            "sa;Password=*29acBgj")]
        public string DayXConnectionString {
            get {
                return ((string)(this["DayXConnectionString"]));
            }
            set { this["DayXConnectionString"] = value; }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("OU=NCH,DC=prettl,DC=local")]
        public string sDefaultOU {
            get {
                return ((string)(this["sDefaultOU"]));
            }
            set {
                this["sDefaultOU"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("test")]
        public string AD_user_name {
            get {
                return ((string)(this["AD_user_name"]));
            }
            set {
                this["AD_user_name"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("test")]
        public string AD_user_password {
            get {
                return ((string)(this["AD_user_password"]));
            }
            set {
                this["AD_user_password"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\\\svru1file01\\groups\\DD\\000_DRW\\000_Initialisation")]
        public string PathForSaveFile {
            get {
                return ((string)(this["PathForSaveFile"]));
            }
            set {
                this["PathForSaveFile"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool EmailChecker {
            get {
                return ((bool)(this["EmailChecker"]));
            }
            set {
                this["EmailChecker"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("svru1mysql01")]
        public string DB_IP {
            get {
                return ((string)(this["DB_IP"]));
            }
            set {
                this["DB_IP"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("adm")]
        public string DB_Login {
            get {
                return ((string)(this["DB_Login"]));
            }
            set {
                this["DB_Login"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("EwS@Y*WYe9Lv")]
        public string DB_Pass {
            get {
                return ((string)(this["DB_Pass"]));
            }
            set {
                this["DB_Pass"] = value;
            }
        }
    }
}
