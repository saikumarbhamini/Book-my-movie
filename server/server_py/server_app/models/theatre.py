#################################################################################

#################################################################################
from django.db import models
from server_py.server_app.models import M

#################################################################################


class ScreenShowMappers(models.Model):
    id = models.AutoField(db_column="Id", primary_key=True)
    show_id = models.ForeignKey(
        "Shows", models.DO_NOTHING, db_column="ShowId", blank=True, null=True
    )
    screen_id = models.ForeignKey(
        "TheatreScreens", models.DO_NOTHING, db_column="ScreenId", blank=True, null=True
    )

    class Meta:
        managed = False
        db_table = "ScreenShowMappers"


class Seats(models.Model):
    id = models.AutoField(db_column="Id", primary_key=True)
    screen_id = models.ForeignKey(
        "TheatreScreens", models.DO_NOTHING, db_column="ScreenId"
    )
    row = models.CharField(
        db_column="Row", max_length=10, db_collation="SQL_Latin1_General_CP1_CI_AS"
    )
    number = models.IntegerField(db_column="Number")
    status = models.BooleanField(db_column="Status")

    class Meta:
        managed = False
        db_table = "Seats"


class Shows(models.Model):
    id = models.AutoField(db_column="Id", primary_key=True)
    movie_imdb_id = models.ForeignKey(
        Movies, models.DO_NOTHING, db_column="MovieImdbId"
    )
    showtime = models.DateTimeField(db_column="ShowTime")

    class Meta:
        managed = False
        db_table = "Shows"


class TheatreScreens(models.Model):
    id = models.AutoField(db_column="Id", primary_key=True)
    screen_name = models.CharField(
        db_column="ScreenName",
        max_length=20,
        db_collation="SQL_Latin1_General_CP1_CI_AS",
        blank=True,
        null=True,
    )
    theater_id = models.ForeignKey(
        MovieTheaters, models.DO_NOTHING, db_column="TheaterId", blank=True, null=True
    )

    class Meta:
        managed = False
        db_table = "TheatreScreens"


class TicketPrices(models.Model):
    id = models.AutoField(db_column="Id", primary_key=True)
    class_field = models.CharField(
        db_column="Class", max_length=20, db_collation="SQL_Latin1_General_CP1_CI_AS"
    )
    show_id = models.ForeignKey(Shows, models.DO_NOTHING, db_column="ShowId")
    price = models.FloatField(db_column="Price")

    class Meta:
        managed = False
        db_table = "TicketPrices"
