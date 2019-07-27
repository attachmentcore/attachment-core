using System;
using System.Collections.Generic;
using System.Text;

namespace AttachmentSystem.Common.Models.Authorization
{
    class CreatePermissionModel
    {
        public string EntityName { get; set; }
        public string FieldName { get; set; }
        public string EntityId { get; set; }
    }
}
