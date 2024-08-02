#################################################################################

#################################################################################
from django.db import models


#################################################################################


class MovieDetails(models.Model):
    imdb = models.OneToOneField("Movies", models.DO_NOTHING, primary_key=True)
    title = models.CharField(
        max_length=255, db_collation="SQL_Latin1_General_CP1_CI_AS"
    )
    original_title = models.CharField(
        max_length=255,
        db_collation="SQL_Latin1_General_CP1_CI_AS",
        blank=True,
        null=True,
    )
    is_adult = models.BooleanField(blank=True, null=True)
    year_of_release = models.IntegerField(blank=True, null=True)
    runtime = models.IntegerField(blank=True, null=True)
    genres = models.CharField(
        max_length=255,
        db_collation="SQL_Latin1_General_CP1_CI_AS",
        blank=True,
        null=True,
    )

    class Meta:
        managed = False
        db_table = "MovieDetails"


class MovieRatings(models.Model):
    imdb = models.OneToOneField("Movies", models.DO_NOTHING, primary_key=True)
    imdb_rating = models.DecimalField(
        max_digits=3, decimal_places=1, blank=True, null=True
    )
    imdb_votes = models.IntegerField(blank=True, null=True)

    class Meta:
        managed = False
        db_table = "MovieRatings"


class MovieTheaters(models.Model):
    id = models.AutoField(db_column="Id", primary_key=True)
    name = models.CharField(
        db_column="Name", max_length=225, db_collation="SQL_Latin1_General_CP1_CI_AS"
    )
    location = models.CharField(
        db_column="Location",
        max_length=225,
        db_collation="SQL_Latin1_General_CP1_CI_AS",
        blank=True,
        null=True,
    )
    is_open = models.BooleanField(db_column="IsOpen")
    screens = models.IntegerField(db_column="Screens")

    class Meta:
        managed = False
        db_table = "MovieTheaters"


class Movies(models.Model):
    title = models.CharField(max_length=50, db_collation="SQL_Latin1_General_CP1_CI_AS")
    imdb_id = models.CharField(
        primary_key=True, max_length=30, db_collation="SQL_Latin1_General_CP1_CI_AS"
    )
    poster_path = models.CharField(
        max_length=255,
        db_collation="SQL_Latin1_General_CP1_CI_AS",
        blank=True,
        null=True,
    )
    wiki_link = models.CharField(
        max_length=255,
        db_collation="SQL_Latin1_General_CP1_CI_AS",
        blank=True,
        null=True,
    )

    class Meta:
        managed = False
        db_table = "Movies"


class MovieAdditionalInfo(models.Model):
    imdb = models.OneToOneField("Movies", models.DO_NOTHING, primary_key=True)
    story = models.TextField(
        db_collation="SQL_Latin1_General_CP1_CI_AS", blank=True, null=True
    )
    summary = models.TextField(
        db_collation="SQL_Latin1_General_CP1_CI_AS", blank=True, null=True
    )
    tagline = models.CharField(
        max_length=255,
        db_collation="SQL_Latin1_General_CP1_CI_AS",
        blank=True,
        null=True,
    )
    actors = models.TextField(
        db_collation="SQL_Latin1_General_CP1_CI_AS", blank=True, null=True
    )
    wins_nominations = models.CharField(
        max_length=255,
        db_collation="SQL_Latin1_General_CP1_CI_AS",
        blank=True,
        null=True,
    )
    release_date = models.DateField(blank=True, null=True)

    class Meta:
        managed = False
        db_table = "MovieAdditionalInfo"
