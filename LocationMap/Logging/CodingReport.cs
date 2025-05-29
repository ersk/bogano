using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationMap.Logging
{
    public class CodingReportMessage
    {
        //public enum ImportanceEnum
        //{
        //    Trace,
        //    Info,
        //    Warning,
        //    Error,
        //    Critical
        //}

        //public ImportanceEnum Importance { get; }
        public string Code { get; }
        public string Message { get; }

        public CodingReportMessage(/*ImportanceEnum importance,*/ string code, string message)
        {
            //Importance = importance;

            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentException($"Parameter for argument {nameof(code)} was empty.", nameof(code));

            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException($"Parameter for argument {nameof(message)} was empty.", nameof(message));

            Code = code;
            Message = message;
        }

        public override string ToString()
        {
            return $"[{Code}] {Message}";
        }
    }
    public class CodingReport
    {
        private IList<CodingReportMessage>? infos { get; set; }
        private IList<CodingReportMessage>? warnings { get; set; }
        private IList<CodingReportMessage>? errors { get; set; }

        public bool HasInfos => infos != null && infos.Any();
        public IList<CodingReportMessage>? Infos => infos;

        public bool HasWarnings => warnings != null && warnings.Any();
        public IList<CodingReportMessage>? Warnings => warnings;

        public bool HasErrors => errors != null && errors.Any();
        public IList<CodingReportMessage>? Errors => errors;


        public bool HasMessages => HasInfos || HasWarnings || HasErrors;

        //public IEnumerable<CodingReportMessage>? messages
        //{
        //    get
        //    {
        //        List<CodingReportMessage> messages = new List<CodingReportMessage>();

        //        if (errors != null)
        //        {
        //            messages.AddRange(errors);
        //        }
        //        if (warnings != null)
        //        {
        //            messages.AddRange(warnings);
        //        }
        //        if (infos != null)
        //        {
        //            messages.AddRange(infos);
        //        }

        //        return messages;
        //    }
        //}

        public void AddInfo(CodingReportMessage message)
        {
            if (infos == null) infos = new List<CodingReportMessage>();
            infos.Add(message);
        }
        public void AddInfo(string code, string message)
        {
            AddInfo(new CodingReportMessage(code, message));
        }

        public void AddWarnings(CodingReportMessage message)
        {
            if (warnings == null) warnings = new List<CodingReportMessage>();
            warnings.Add(message);
        }
        public void AddWarnings(string code, string message)
        {
            AddWarnings(new CodingReportMessage(code, message));
        }

        public void AddErrors(CodingReportMessage message)
        {
            if (errors == null) errors = new List<CodingReportMessage>();
            errors.Add(message);
        }
        public void AddErrors(string code, string message)
        {
            AddErrors(new CodingReportMessage(code, message));
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine("Coding Report:");

            if (HasMessages == false)
            {
                sb.AppendLine("\tNo messages.");
                return sb.ToString();
            }

            if (HasErrors)
            {
                sb.AppendLine("\tErrors:");
                foreach (var error in errors!)
                {
                    sb.AppendLine("\t\t" + error.ToString());
                }
            }
            if (HasWarnings)
            {
                sb.AppendLine("\tWarnings:");
                foreach (var error in errors!)
                {
                    sb.AppendLine("\t\t" + error.ToString());
                }
            }
            if (HasInfos)
            {
                sb.AppendLine("\tInfors:");
                foreach (var error in errors!)
                {
                    sb.AppendLine("\t\t" + error.ToString());
                }
            }

            return sb.ToString();
        }

        public CodingReport? Clone()
        {
            CodingReport newCodingReport = null;

            if (HasInfos)
            {
                newCodingReport ??= new();
                newCodingReport.infos = infos;
            }
            if (HasWarnings)
            {
                newCodingReport ??= new();
                newCodingReport.warnings = warnings;
            }
            if (HasErrors)
            {
                newCodingReport ??= new();
                newCodingReport.errors = errors;
            }

            return newCodingReport;
        }
        public static CodingReport? Combine(CodingReport? a, CodingReport? b)
        {
            CodingReport? newCodingReport = null;

            if (a != null)
            {
                newCodingReport = a.Clone();
            }

            if (b != null)
            {

                if (b.HasInfos)
                {
                    newCodingReport ??= new();

                    if (newCodingReport.infos == null)
                    {
                        newCodingReport.infos = b.infos;
                    }
                    else
                    {
                        var tempList = newCodingReport.infos.ToList();
                        tempList.AddRange(b.infos!);
                        newCodingReport.infos = tempList;
                    }
                }
                if (b.HasWarnings)
                {
                    newCodingReport ??= new();

                    if (newCodingReport.warnings == null)
                    {
                        newCodingReport.warnings = b.warnings;
                    }
                    else
                    {
                        var tempList = newCodingReport.warnings.ToList();
                        tempList.AddRange(b.warnings!);
                        newCodingReport.warnings = tempList;
                    }
                }
                if (b.HasErrors)
                {
                    newCodingReport ??= new();

                    if (newCodingReport.errors == null)
                    {
                        newCodingReport.errors = b.errors;
                    }
                    else
                    {
                        var tempList = newCodingReport.errors.ToList();
                        tempList.AddRange(b.errors!);
                        newCodingReport.errors = tempList;
                    }
                }
            }

            return newCodingReport;
        }

    }
}
