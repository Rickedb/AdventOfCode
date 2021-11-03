using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day06
{
    public class Day06Resolver : IAdventResolver
    {
        private readonly IEnumerable<DeclarationGroup> _declarationGroups;

        public Day06Resolver(string declarationResponses)
        {
            _declarationGroups = ParseDeclarations(declarationResponses);
        }

        public object ResolvePartOne()
        {
            var totalYes = 0;
            foreach (var group in _declarationGroups)
            {
                var yesAnswerByGroup = new List<char>();
                foreach (var response in group.Responses)
                {
                    foreach (var yesAnswer in response.QuestionsAnsweredWithYes)
                    {
                        if (!yesAnswerByGroup.Contains(yesAnswer))
                        {
                            yesAnswerByGroup.Add(yesAnswer);
                        }
                    }

                }

                totalYes += yesAnswerByGroup.Count;
            }

            return totalYes;
        }

        public object ResolvePartTwo()
        {
            var totalYes = 0;
            foreach (var group in _declarationGroups)
            {
                var yesAnswerByGroup = new List<char>();
                var distinctAnswers = group.Responses.SelectMany(x => x.QuestionsAnsweredWithYes).Distinct();
                foreach (var answer in distinctAnswers)
                {
                    if (group.Responses.All(x => x.QuestionsAnsweredWithYes.Contains(answer)))
                    {
                        totalYes++;
                    }
                }
            }

            return totalYes;
        }

        private IEnumerable<DeclarationGroup> ParseDeclarations(string declarations)
        {
            var groups = declarations.Split("\r\n\r\n");
            var declarationGroups = new List<DeclarationGroup>();
            foreach (var group in groups)
            {
                var newGroupResponses = new List<DeclarationResponse>();
                var responses = group.Split("\r\n");
                foreach (var response in responses)
                {
                    newGroupResponses.Add(new DeclarationResponse() { QuestionsAnsweredWithYes = response.ToList() });
                }

                declarationGroups.Add(new DeclarationGroup() { Responses = newGroupResponses });
            }

            return declarationGroups;
        }
    }
}
