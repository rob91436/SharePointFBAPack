using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint;
using System.Web.Security;
using System.Web.UI.WebControls;
using System;

namespace Visigo.Sharepoint.FormsBasedAuthentication
{
    /// <summary>
    /// Code behind for UsersDisp.aspx
    /// </summary>
    public partial class FBASiteConfiguration : LayoutsPageBase
    {

        protected override bool RequireSiteAdministrator
        {
            get { return true; }
        }

        protected override void OnLoad(EventArgs e)
        {
            if (!IsPostBack)
            {
                MembershipSettings settings = new MembershipSettings(SPContext.Current.Web);

                /* Set the options in the web properties */
                chkEnableRoles.Checked = settings.EnableRoles;
                chkReviewMembershipRequests.Checked = settings.ReviewMembershipRequests;

                /* bms Set the URL strings in the web properties */
                txtChangePasswordPage.Text = settings.ChangePasswordPage;
                txtPasswordQuestionPage.Text = settings.PasswordQuestionPage;
                txtThankYouPage.Text = settings.ThankYouPage;

                /* bms Set the XSLT location web properties */
                txtMembershipApproved.Text = settings.MembershipApprovedEmail;
                txtMembershipError.Text = settings.MembershipErrorEmail;
                txtMembershipPending.Text = settings.MembershipPendingEmail;
                txtMembershipRejected.Text = settings.MembershipRejectedEmail;
                txtPasswordRecovery.Text = settings.PasswordRecoveryEmail;
            }
        }

        protected void BtnUpdateSiteFBAConfig_Click(object sender, EventArgs e)
        {
            MembershipSettings settings = new MembershipSettings(SPContext.Current.Web);

            /* Set the options in the web properties */
            settings.EnableRoles = chkEnableRoles.Checked;
            settings.ReviewMembershipRequests = chkReviewMembershipRequests.Checked;

            /* bms Set the URL strings in the web properties */
            settings.ChangePasswordPage = txtChangePasswordPage.Text;
            settings.PasswordQuestionPage = txtPasswordQuestionPage.Text;
            settings.ThankYouPage = txtThankYouPage.Text;

            /* bms Set the XSLT location web properties */
            settings.MembershipApprovedEmail = txtMembershipApproved.Text;
            settings.MembershipErrorEmail = txtMembershipError.Text;
            settings.MembershipPendingEmail = txtMembershipPending.Text;
            settings.MembershipRejectedEmail = txtMembershipRejected.Text;
            settings.PasswordRecoveryEmail = txtPasswordRecovery.Text;
        }
                
    }
}