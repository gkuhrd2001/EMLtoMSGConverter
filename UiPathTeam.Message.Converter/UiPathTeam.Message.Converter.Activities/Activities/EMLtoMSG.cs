using System;
using System.Activities;
using System.Threading;
using System.Threading.Tasks;
using UiPathTeam.Message.Converter.Activities.Properties;
using UiPath.Shared.Activities;
using UiPath.Shared.Activities.Localization;
using MsgKit;

namespace UiPathTeam.Message.Converter.Activities
{
    [LocalizedDisplayName(nameof(Resources.EMLtoMSG_DisplayName))]
    [LocalizedDescription(nameof(Resources.EMLtoMSG_Description))]
    public class EMLtoMSG : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.EMLFileName_DisplayName))]
        [LocalizedDescription(nameof(Resources.EMLFileName_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> EMLFileName { get; set; }

        [LocalizedDisplayName(nameof(Resources.MSGFileName_DisplayName))]
        [LocalizedDescription(nameof(Resources.MSGFileName_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> MSGFileName { get; set; }

        #endregion


        #region Constructors

        public EMLtoMSG()
        {
        }

        #endregion


        #region Protected Methods

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {

            base.CacheMetadata(metadata);
        }

        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken)
        {
            // Inputs
            string emlFileName = EMLFileName.Get(context);
            string msgFileName = MSGFileName.Get(context);
    
            ///////////////////////////
            MsgKit.Converter.ConvertEmlToMsg(emlFileName, msgFileName);
            ///////////////////////////

            // Outputs
            return (ctx) => {
            };
        }

        #endregion
    }
}

