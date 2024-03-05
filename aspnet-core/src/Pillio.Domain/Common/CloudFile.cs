using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Pillio.Common;

[Table("CloudFiles")]
public class CloudFile : FullAuditedEntity<Guid>, IMultiTenant
{
    public Guid? TenantId { get; set; }

    public Guid CloudFileId { get; set; }

    public string? FileName { get; set; }

    public string? FileExtension { get; set; }
    public long FileSize { get; set; }
    public bool IsCloudFileDeleted { get; set; }

    public string? AudioTranscript { get; set; }

    public string? Notes { get; set; }

    public CloudFileType? Type { get; set; } = CloudFileType.Google;

    public string? CloudUrl { get; set; }

    public CloudFileMetaData MetaData { get; set; }
}

[NotMapped]
public class CloudFileMetaData { }

public enum CloudFileType
{
    Google = 0,
    Azure = 1,
    AWS = 2
}