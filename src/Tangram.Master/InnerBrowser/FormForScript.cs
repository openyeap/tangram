﻿

using System.Runtime.InteropServices;
using System.Security.Permissions;
using Tangram.Core;

namespace Tangram.IEBrowser
{

    [PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
    [ComVisibleAttribute(true)]
    public class FormForScript
    {
        private IFormBrowser form;
        public FormForScript(IFormBrowser form)
        {
            this.form = form;
        }
        public FormForScript show(string parent = "")
        {
            this.form.show(parent);
            return new FormForScript(form);
        }
        public FormForScript close()
        {
            this.form.close();
            return new FormForScript(form);
        }
        public FormForScript hide()
        {
            this.form.hide();
            return new FormForScript(form);
        }
        public FormForScript size(int width, int height)
        {
            this.form.size(width, height);
            return new FormForScript(form);
        }
        public FormForScript site(int left, int top)
        {
            this.form.site(left, top);
            return new FormForScript(form);
        }
        public FormForScript refresh(string url = "")
        {
            this.form.refresh(url);
            return new FormForScript(form);
        }
        public FormForScript exec(string script)
        {
            this.form.exec(script);
            return new FormForScript(form);
        }
        public FormForScript mode(int status)
        {
            this.form.mode(status);
            return new FormForScript(form);
        }
    }

}