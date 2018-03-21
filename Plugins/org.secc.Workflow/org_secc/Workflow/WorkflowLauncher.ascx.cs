// <copyright>
// Copyright Southeast Christian Church
//
// Licensed under the  Southeast Christian Church License (the "License");
// you may not use this file except in compliance with the License.
// A copy of the License shoud be included with this file.
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//
// <copyright>
// Copyright by the Spark Development Network
//
// Licensed under the Rock Community License (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.rockrms.com/license
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//
using System;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Rock;
using Rock.Data;
using Rock.Model;
using Rock.Web.UI;

namespace RockWeb.Plugins.org_secc.Workflow
{
    /// <summary>
    /// Block for launching workflows for common entity types.
    /// </summary>
    [DisplayName( "Workflow Launcher" )]
    [Category( "SECC > Workflow" )]
    [Description( "Block for launching workflows for common entity types" )]
    public partial class WorkflowLauncher : RockBlock
    {


        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnInit( EventArgs e )
        {
            base.OnInit( e );
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Load" /> event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad( e );

            if ( !Page.IsPostBack )
            {
                BindData();
            }
        }


        /// <summary>
        /// Binds the dropdown menus
        /// </summary>
        private void BindData()
        {

            using ( var rockContext = new RockContext() )
            {
                RegistrationInstanceService registrationInstanceService = new RegistrationInstanceService( rockContext );

                var registrationInstances = registrationInstanceService.Queryable().AsNoTracking().ToList();
                ddlRegistrationInstances.DataSource = registrationInstances;
                RegistrationInstance emptyRegistrationInstance = new RegistrationInstance { Id = -1, Name = "" };
                registrationInstances.Insert( 0, emptyRegistrationInstance );
                ddlRegistrationInstances.DataBind();
            }
        }


        /// <summary>
        /// Handles the SelectedIndexChanged event of the ddlRegistrationInstances control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void ddlRegistrationInstances_SelectedIndexChanged( object sender, EventArgs e )
        {
            int? registrationInstanceId = ddlRegistrationInstances.SelectedValueAsInt();
            if ( registrationInstanceId.HasValue && registrationInstanceId.Value != -1 )
            {
                BindRegistrationsUsingRegistrationInstances( registrationInstanceId.Value );
            }
        }


        /// <summary>
        /// Binds the Registrations (people who registered) using the RegistrationInstances.
        /// </summary>
        private void BindRegistrationsUsingRegistrationInstances( int? registrationInstanceId )
        {
            if ( registrationInstanceId == -1 )
            {
                return;
            }

            using ( var rockContext = new RockContext() )
            {
                RegistrationService registrationService = new RegistrationService( rockContext );

                var registrations = registrationService.Queryable().AsNoTracking().Where( r => r.RegistrationInstanceId == registrationInstanceId.Value ).ToList();
                Registration emptyRegistration = new Registration { Id = -1, FirstName = "" };
                registrations.Insert( 0, emptyRegistration );
                ddlRegistrations.DataSource = registrations;
                ddlRegistrations.Visible = true;
                ddlRegistrations.DataBind();
                
            }
        }
        
        protected void Launch_Click( object sender, EventArgs e )
        {
            if (!wtpWorkflowType.SelectedValueAsInt().HasValue)
            {
                return;
            }
            using ( var rockContext = new RockContext() )
            {
                litOutput.Text = "";
                RegistrationService registrationService = new RegistrationService( rockContext );

                if ( ddlRegistrations.SelectedValueAsInt().HasValue && ddlRegistrations.SelectedValueAsInt() > 0)
                {
                    var registration = registrationService.Get( ddlRegistrations.SelectedValueAsInt().Value );
                    registration.LaunchWorkflow( wtpWorkflowType.SelectedValueAsInt().Value, registration.ToString() );
                }
                else if ( ddlRegistrationInstances.SelectedValueAsInt().HasValue && ddlRegistrationInstances.SelectedValueAsInt() > 0 )
                {
                    int registrationInstanceId = ddlRegistrationInstances.SelectedValueAsInt().Value;
                    var registrations = registrationService.Queryable().Where( r => r.RegistrationInstanceId == registrationInstanceId );
                    foreach ( Registration registration in registrations )
                    {

                        litOutput.Text += "Launching workflow for " + registration.ToString() + "<br />";
                        registration.LaunchWorkflow( wtpWorkflowType.SelectedValueAsInt().Value, registration.ToString() );
                    }
                }
            }
        }
    }
}