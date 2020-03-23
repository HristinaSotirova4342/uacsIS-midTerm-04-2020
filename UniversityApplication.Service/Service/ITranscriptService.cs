using System.Collections.Generic;

using UniversityApplication.Data.DTOs;

namespace UniversityApplication.Service.Service
{
    public interface ITranscriptService
    {
        IEnumerable<TranscriptDTO> GetTranscripts();

        IEnumerable<TranscriptDTO> GetTranscripts(int studentId);

        TranscriptDTO GetTranscript(int studentId, int examId);

        TranscriptDTO SaveTranscript(TranscriptDTO transcript);

        bool DeleteTranscript(int id);

        TranscriptDTO PutPoints(int id, TranscriptDTO transcriptObject);

    }
}
