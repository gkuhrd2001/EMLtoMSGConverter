using System.Activities.Presentation.Metadata;
using System.ComponentModel;
using System.ComponentModel.Design;
using UiPathTeam.Message.Converter.Activities.Design.Designers;
using UiPathTeam.Message.Converter.Activities.Design.Properties;

namespace UiPathTeam.Message.Converter.Activities.Design
{
    public class DesignerMetadata : IRegisterMetadata
    {
        public void Register()
        {
            var builder = new AttributeTableBuilder();
            builder.ValidateTable();

            var categoryAttribute = new CategoryAttribute($"{Resources.Category}");

            builder.AddCustomAttributes(typeof(EMLtoMSG), categoryAttribute);
            builder.AddCustomAttributes(typeof(EMLtoMSG), new DesignerAttribute(typeof(EMLtoMSGDesigner)));
            builder.AddCustomAttributes(typeof(EMLtoMSG), new HelpKeywordAttribute(""));

          


            MetadataStore.AddAttributeTable(builder.CreateTable());
        }
    }
}
