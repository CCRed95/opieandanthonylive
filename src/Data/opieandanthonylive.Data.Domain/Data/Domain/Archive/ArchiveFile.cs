using Ccr.Data.EntityFrameworkCore.Infrastucture;
using Ccr.Std.Core.Extensions;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace opieandanthonylive.Data.Domain.Archive
{
	// ReSharper disable VirtualMemberCallInConstructor
	public class ArchiveFile
		: EntityBase
	{
		public int ArchiveFileID { get; set; }

		public string FileName { get; set; }


		public int? ArchiveFileTypeInfoID { get; set; }
		[CanBeNull, ForeignKey("ArchiveFileTypeInfoID")]
		public virtual ArchiveFileTypeInfo ArchiveFileTypeInfo { get; set; }


		public int? ShowID { get; set; }
		[CanBeNull, ForeignKey("ShowID")]
		public virtual Show Show { get; set; }


		public int? ArchiveAlbumID { get; set; }
		[CanBeNull, ForeignKey("ArchiveAlbumID")]
		public virtual ArchiveAlbum ArchiveAlbum { get; set; }


		public int? ShowRundownID { get; set; }
		[CanBeNull, ForeignKey("ShowRundownID")]
		public virtual ShowRundown ShowRundown { get; set; }


		public string Identifier { get; set; }

		public string FilePathUrl { get; set; }

		public DateTime AirDate { get; set; }

		public string Title { get; set; }

		public DateTime? LastModifiedDate { get; set; }

		public double ApproximateBytes { get; set; }


		public virtual ICollection<GuestAppearance> GuestAppearances { get; set; }



		private ArchiveFile()
		{
			GuestAppearances = new HashSet<GuestAppearance>();
		}

		public ArchiveFile(
			[NotNull] string fileName,
			[NotNull] ArchiveFileTypeInfo archiveFileTypeInfo,
			[NotNull] Show show,
			[NotNull] ArchiveAlbum archiveAlbum,
			[NotNull] string identifier,
			[NotNull] string filePathUrl,
			DateTime airDate,
			[NotNull] string title,
			DateTime? lastModifiedDate,
			double approximateBytes)
				: this()
		{
			fileName.IsNotNull(nameof(fileName));
			archiveFileTypeInfo.IsNotNull(nameof(archiveFileTypeInfo));
			show.IsNotNull(nameof(show));
			archiveAlbum.IsNotNull(nameof(archiveAlbum));
			identifier.IsNotNull(nameof(identifier));
			title.IsNotNull(nameof(title));

			FileName = fileName;
			ArchiveFileTypeInfoID = archiveFileTypeInfo.ArchiveFileTypeInfoID;
			ShowID = show.ShowID;
			ArchiveAlbum = archiveAlbum;
			Identifier = identifier;
			FilePathUrl = filePathUrl;
			AirDate = airDate;
			Title = title;
			LastModifiedDate = lastModifiedDate;
			ApproximateBytes = approximateBytes;
		}

		public ArchiveFile(
			int archiveFileID,
			[NotNull] string fileName,
			[NotNull] ArchiveFileTypeInfo archiveFileTypeInfo,
			[NotNull] Show show,
			[NotNull] ArchiveAlbum archiveAlbum,
			[NotNull] string identifier,
			[NotNull] string filePathUrl,
			DateTime airDate,
			[NotNull] string title,
			DateTime lastModifiedDate,
			double approximateBytes)
				: this(
					fileName,
					archiveFileTypeInfo,
					show,
					archiveAlbum,
					identifier,
					filePathUrl,
					airDate,
					title,
					lastModifiedDate,
					approximateBytes)
		{
			ArchiveFileID = archiveFileID;
		}
	}
}