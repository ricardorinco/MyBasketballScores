using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBasketballScores.Domain.Entities;

namespace MyBasketballScores.Infra.Data.Persistences.DataContext.Maps
{
    public class ScoreMap : IEntityTypeConfiguration<Score>
    {
        public void Configure(EntityTypeBuilder<Score> builder)
        {
            // Nome da tabela
            builder.ToTable("Score");

            // Chave primária
            builder.HasKey(x => x.Id);

            // Propriedades
            builder.Property(x => x.GameDate).IsRequired();
            builder.Property(x => x.TotalScore).IsRequired();
        }
    }
}
