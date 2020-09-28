namespace Schmidt.Softplan.TechnicalEvaluation.Common.SqlQueries
{
    public static class ProcessoHierarchy
    {
        public static string ProcessosFilhos =
            @"
            with recursive recursive_(id, processoPaiID) as (
                select id, processoPaiID from Processos where id = @processoID
                union all
                select p.id, p.processoPaiID from recursive_ as r, processos as p
                where r.id = p.processoPaiID
            )
            select id from recursive_
            ";
    }
}
