using malo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;

namespace malo.Data
{
    static class Repository
    {
        // static class for general functions that access the database 

        static public List<Iwad> GetIwads()
        {
            var iwads = new List<Iwad>();
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            string databaseLocation = "Data Source=";
            databaseLocation += System.AppDomain.CurrentDomain.BaseDirectory;
            databaseLocation += "malo.db";
            optionsBuilder.UseSqlite(databaseLocation);
            using (Context context = new Context(optionsBuilder.Options))
            {
                iwads.AddRange(context.Iwads.ToList<Iwad>());
            }

            return iwads;
        }

        static public List<SourcePort> GetSourcePorts()
        {
            var sourcePorts = new List<SourcePort>();
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            string databaseLocation = "Data Source=";
            databaseLocation += System.AppDomain.CurrentDomain.BaseDirectory;
            databaseLocation += "malo.db";
            optionsBuilder.UseSqlite(databaseLocation);
            using (Context context = new Context(optionsBuilder.Options))
            {
                sourcePorts.AddRange(context.SourcePorts.ToList<SourcePort>());
            }

            return sourcePorts;
        }

        static public List<Pwad> GetLevelPwads()
        {
            var pwads = new List<Pwad>();
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            string databaseLocation = "Data Source=";
            databaseLocation += System.AppDomain.CurrentDomain.BaseDirectory;
            databaseLocation += "malo.db";
            optionsBuilder.UseSqlite(databaseLocation);
            using (Context context = new Context(optionsBuilder.Options))
            {
                pwads.AddRange(context.Pwads.Where(p => p.IsALevelPack == true).ToList<Pwad>());
            }

            return pwads;
        }

        static public List<Pwad> GetModPwads()
        {
            var pwads = new List<Pwad>();
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            string databaseLocation = "Data Source=";
            databaseLocation += System.AppDomain.CurrentDomain.BaseDirectory;
            databaseLocation += "malo.db";
            optionsBuilder.UseSqlite(databaseLocation);
            using (Context context = new Context(optionsBuilder.Options))
            {
                pwads.AddRange(context.Pwads.Where(p => p.IsAMod == true).ToList<Pwad>());
            }

            return pwads;
        }

        static public SourcePort FindSourcePortByName(string sourcePortName)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            string databaseLocation = "Data Source=";
            databaseLocation += System.AppDomain.CurrentDomain.BaseDirectory;
            databaseLocation += "malo.db";
            optionsBuilder.UseSqlite(databaseLocation);
            using (Context context = new Context(optionsBuilder.Options))
            {
                try
                {
                    var outputSourcePort = context.SourcePorts.First<SourcePort>(s => s.Name == sourcePortName);

                    return outputSourcePort;
                }
                catch
                {
                    return new SourcePort() { FileName = "MALOERROR" };
                }
            }

        }

        static public Iwad FindIwadByName(string iwadName)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            string databaseLocation = "Data Source=";
            databaseLocation += System.AppDomain.CurrentDomain.BaseDirectory;
            databaseLocation += "malo.db";
            optionsBuilder.UseSqlite(databaseLocation);
            using (Context context = new Context(optionsBuilder.Options))
            {
                try
                {
                    var outputIwad = context.Iwads.First<Iwad>(i => i.Name == iwadName);

                    return outputIwad;
                }
                catch
                {
                    return new Iwad() { FileName = "MALOERROR" };
                }
            }

        }

        static public Pwad FindPwadByName(string pwadName)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            string databaseLocation = "Data Source=";
            databaseLocation += System.AppDomain.CurrentDomain.BaseDirectory;
            databaseLocation += "malo.db";
            optionsBuilder.UseSqlite(databaseLocation);
            using (Context context = new Context(optionsBuilder.Options))
            {
                try
                {
                    var outputPwad = context.Pwads.First<Pwad>(s => s.Name == pwadName);

                    return outputPwad;
                }
                catch
                {
                    return new Pwad() { FileName = "MALOERROR" };
                }
            }

        }

        static public Tag FindTagByName(string tagName)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            string databaseLocation = "Data Source=";
            databaseLocation += System.AppDomain.CurrentDomain.BaseDirectory;
            databaseLocation += "malo.db";
            optionsBuilder.UseSqlite(databaseLocation);
            using (Context context = new Context(optionsBuilder.Options))
            {
                try
                {
                    var outputTag = context.Tags.First<Tag>(t => t.Name == tagName);

                    return outputTag;
                }
                catch
                {
                    return new Tag() { Name = "MALOERROR" };
                }
            }

        }

        static public bool CheckIfPwadExistsByFileLocation(Pwad pwad)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            string databaseLocation = "Data Source=";
            databaseLocation += System.AppDomain.CurrentDomain.BaseDirectory;
            databaseLocation += "malo.db";
            optionsBuilder.UseSqlite(databaseLocation);
            using (Context context = new Context(optionsBuilder.Options))
            {
                return (context.Pwads.Any<Pwad>(p => p.FileLocation == pwad.FileLocation)); // returns true if file location match found; false if not.
            }
        }

        static public bool CheckIfIwadExistsByFileLocation(Iwad iwad)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            string databaseLocation = "Data Source=";
            databaseLocation += System.AppDomain.CurrentDomain.BaseDirectory;
            databaseLocation += "malo.db";
            optionsBuilder.UseSqlite(databaseLocation);
            using (Context context = new Context(optionsBuilder.Options))
            {
                return (context.Iwads.Any<Iwad>(i => i.FileLocation == iwad.FileLocation)); // returns true if file location match found; false if not.
            }
        }

        static public bool CheckIfSourcePortExistsByFileLocation(SourcePort sourcePort)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            string databaseLocation = "Data Source=";
            databaseLocation += System.AppDomain.CurrentDomain.BaseDirectory;
            databaseLocation += "malo.db";
            optionsBuilder.UseSqlite(databaseLocation);
            using (Context context = new Context(optionsBuilder.Options))
            {
                return (context.SourcePorts.Any<SourcePort>(s => s.FileLocation == sourcePort.FileLocation)); // returns true if file location match found; false if not.
            }
        }
        static public bool CheckIfTagExistsByName(Tag tag)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            string databaseLocation = "Data Source=";
            databaseLocation += System.AppDomain.CurrentDomain.BaseDirectory;
            databaseLocation += "malo.db";
            optionsBuilder.UseSqlite(databaseLocation);
            using (Context context = new Context(optionsBuilder.Options))
            {
                return (context.Tags.Any<Tag>(t => t.Name == tag.Name)); // returns true if tag name match found; false if not.
            }
        }

        static public bool AddNewPwad(Pwad pwad)
        {
            pwad.Completion = CompletionLevel.NotStarted;

            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            string databaseLocation = "Data Source=";
            databaseLocation += System.AppDomain.CurrentDomain.BaseDirectory;
            databaseLocation += "malo.db";
            optionsBuilder.UseSqlite(databaseLocation);
            using (Context context = new Context(optionsBuilder.Options))
            {
                try
                {
                    context.Pwads.Add(pwad);
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }

        static public bool AddNewIwad(Iwad iwad)
        {
            iwad.IsConfigured = true;

            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            string databaseLocation = "Data Source=";
            databaseLocation += System.AppDomain.CurrentDomain.BaseDirectory;
            databaseLocation += "malo.db";
            optionsBuilder.UseSqlite(databaseLocation);
            using (Context context = new Context(optionsBuilder.Options))
            {
                try
                {
                    context.Iwads.Add(iwad);
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }

        static public bool AddNewSourcePort(SourcePort sourcePort)
        {
            sourcePort.IsConfigured = true;

            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            string databaseLocation = "Data Source=";
            databaseLocation += System.AppDomain.CurrentDomain.BaseDirectory;
            databaseLocation += "malo.db";
            optionsBuilder.UseSqlite(databaseLocation);
            using (Context context = new Context(optionsBuilder.Options))
            {
                try
                {
                    context.SourcePorts.Add(sourcePort);
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }
        static public bool AddNewTag(Tag tag)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            string databaseLocation = "Data Source=";
            databaseLocation += System.AppDomain.CurrentDomain.BaseDirectory;
            databaseLocation += "malo.db";
            optionsBuilder.UseSqlite(databaseLocation);
            using (Context context = new Context(optionsBuilder.Options))
            {
                try
                {
                    context.Tags.Add(tag);
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }

        static public bool ModifySourcePort(SourcePort sourcePort)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            string databaseLocation = "Data Source=";
            databaseLocation += System.AppDomain.CurrentDomain.BaseDirectory;
            databaseLocation += "malo.db";
            optionsBuilder.UseSqlite(databaseLocation);
            using (Context context = new Context(optionsBuilder.Options))
            {
                try
                {
                    var sourcePortToUpdate = context.SourcePorts.First(s => s.FileName == sourcePort.FileName);
                    sourcePortToUpdate.Name = sourcePort.Name;
                    sourcePortToUpdate.MaximumCompatibility = sourcePort.MaximumCompatibility;
                    context.SourcePorts.Update(sourcePortToUpdate);
                    context.SaveChanges();
                }
                catch
                {
                    return false;
                }


            }
            return true;
        }
        static public bool DeleteSourcePortByName(SourcePort sourcePort)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            string databaseLocation = "Data Source=";
            databaseLocation += System.AppDomain.CurrentDomain.BaseDirectory;
            databaseLocation += "malo.db";
            optionsBuilder.UseSqlite(databaseLocation);
            using (Context context = new Context(optionsBuilder.Options))
            {
                try
                {
                    var sourcePortToUpdate = context.SourcePorts.First(s => s.FileName == sourcePort.FileName);
                    context.SourcePorts.Remove(sourcePortToUpdate);
                    context.SaveChanges();
                }
                catch
                {
                    return false;
                }


            }
            return true;
        }

        static public bool ModifyIwad(Iwad iwad)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            string databaseLocation = "Data Source=";
            databaseLocation += System.AppDomain.CurrentDomain.BaseDirectory;
            databaseLocation += "malo.db";
            optionsBuilder.UseSqlite(databaseLocation);
            using (Context context = new Context(optionsBuilder.Options))
            {
                try
                {
                    var iwadToUpdate = context.Iwads.First(i => i.FileName == iwad.FileName);
                    iwadToUpdate.Name = iwad.Name;
                    context.Iwads.Update(iwadToUpdate);
                    context.SaveChanges();
                }
                catch
                {
                    return false;
                }


            }
            return true;
        }

        static public bool DeleteIwadByName(Iwad iwad)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            string databaseLocation = "Data Source=";
            databaseLocation += System.AppDomain.CurrentDomain.BaseDirectory;
            databaseLocation += "malo.db";
            optionsBuilder.UseSqlite(databaseLocation);
            using (Context context = new Context(optionsBuilder.Options))
            {
                try
                {
                    var iwadToUpdate = context.Iwads.First(i => i.FileName == iwad.FileName);
                    context.Iwads.Remove(iwadToUpdate);
                    context.SaveChanges();
                }
                catch
                {
                    return false;
                }


            }
            return true;
        }

        static public bool ModifyPwad(Pwad pwad)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            string databaseLocation = "Data Source=";
            databaseLocation += System.AppDomain.CurrentDomain.BaseDirectory;
            databaseLocation += "malo.db";
            optionsBuilder.UseSqlite(databaseLocation);
            using (Context context = new Context(optionsBuilder.Options))
            {
                try
                {
                    var pwadToUpdate = context.Pwads.First(p => p.FileName == pwad.FileName);
                    pwadToUpdate.Name = pwad.Name;
                    pwadToUpdate.IsAMod = pwad.IsAMod;
                    pwadToUpdate.IsALevelPack = pwad.IsALevelPack;
                    pwadToUpdate.RequiredCompatibility = pwad.RequiredCompatibility;

                    context.Pwads.Update(pwadToUpdate);
                    context.SaveChanges();
                }
                catch
                {
                    return false;
                }


            }
            return true;
        }

        static public bool DeletePwadByName(Pwad pwad)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            string databaseLocation = "Data Source=";
            databaseLocation += System.AppDomain.CurrentDomain.BaseDirectory;
            databaseLocation += "malo.db";
            optionsBuilder.UseSqlite(databaseLocation);
            using (Context context = new Context(optionsBuilder.Options))
            {
                try
                {
                    var pwadToUpdate = context.Pwads.First(p => p.FileName == pwad.FileName);
                    context.Pwads.Remove(pwadToUpdate);
                    context.SaveChanges();
                }
                catch
                {
                    return false;
                }


            }
            return true;
        }
        static public bool DeleteTagByName(Tag tag)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            string databaseLocation = "Data Source=";
            databaseLocation += System.AppDomain.CurrentDomain.BaseDirectory;
            databaseLocation += "malo.db";
            optionsBuilder.UseSqlite(databaseLocation);
            using (Context context = new Context(optionsBuilder.Options))
            {
                try
                {
                    var tagToUpdate = context.Tags.First(t => t.Name == tag.Name);
                    context.Tags.Remove(tagToUpdate);
                    context.SaveChanges();
                }
                catch
                {
                    return false;
                }


            }
            return true;
        }

        static public List<Tag> GetTags()
        {
            var tags = new List<Tag>();
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            string databaseLocation = "Data Source=";
            databaseLocation += System.AppDomain.CurrentDomain.BaseDirectory;
            databaseLocation += "malo.db";
            optionsBuilder.UseSqlite(databaseLocation);
            using (Context context = new Context(optionsBuilder.Options))
            {
                tags.AddRange(context.Tags.ToList<Tag>());
            }
            return tags;
        }

        static public bool CheckPwadForTag(Pwad pwad, Tag tag)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            string databaseLocation = "Data Source=";
            databaseLocation += System.AppDomain.CurrentDomain.BaseDirectory;
            databaseLocation += "malo.db";
            optionsBuilder.UseSqlite(databaseLocation);
            using (Context context = new Context(optionsBuilder.Options))
            {
                try
                {
                    var pwadInTable = context.Pwads.Include(p => p.PwadTags).First(p => p.Name == pwad.Name);
                    var tagInTable = context.Tags.First(t => t.Name == tag.Name);

                    return (pwadInTable.PwadTags.Any(pt => pt.Tag.Id == tagInTable.Id));
                }
                catch(Exception e)
                {
                    return false;
                }
            }
        }

        static public bool AddTagToPwad(Tag tag, Pwad pwad)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            string databaseLocation = "Data Source=";
            databaseLocation += System.AppDomain.CurrentDomain.BaseDirectory;
            databaseLocation += "malo.db";
            optionsBuilder.UseSqlite(databaseLocation);
            using (Context context = new Context(optionsBuilder.Options))
            {
                var pwadInTable = context.Pwads.First(p => p.Name == pwad.Name);
                var tagInTable = context.Tags.First(t => t.Name == tag.Name);
                PwadTag pwadTag = new PwadTag()
                {
                    Pwad = pwadInTable,
                    Tag = tagInTable
                };

                pwadInTable.PwadTags.Add(pwadTag);
                tagInTable.PwadTags.Add(pwadTag);

                context.Pwads.Update(pwadInTable);
                context.Tags.Update(tagInTable);
                context.SaveChanges();
            }

            return true;
        }

        static public bool ModifyTag(Tag tag, List<Pwad> pwads)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            string databaseLocation = "Data Source=";
            databaseLocation += System.AppDomain.CurrentDomain.BaseDirectory;
            databaseLocation += "malo.db";
            optionsBuilder.UseSqlite(databaseLocation);
            using (Context context = new Context(optionsBuilder.Options))
            {
                var tagInTable = context.Tags.Include(t => t.PwadTags).First(t => t.Name == tag.Name);
                tagInTable.PwadTags.Clear();
                tagInTable.Description = tag.Description;

                foreach (Pwad p in pwads)
                {
                    tagInTable.PwadTags.Add(new PwadTag() { PwadId = p.Id, TagId = tagInTable.Id });
                }
                context.Tags.Update(tagInTable);
                context.SaveChanges();

                return true;
            }
        }
    }
}
