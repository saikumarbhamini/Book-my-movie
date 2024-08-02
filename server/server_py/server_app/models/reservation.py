#################################################################################

#################################################################################
from django.db import models

#################################################################################
from server_py.server_app.models import UserData


class ReservationSeat(models.Model):
    reservations_id = models.OneToOneField(
        "Reservations", models.DO_NOTHING, db_column="ReservationsId", primary_key=True
    )
    seats_id = models.ForeignKey("Seats", models.DO_NOTHING, db_column="SeatsId")

    class Meta:
        managed = False
        db_table = "ReservationSeat"
        unique_together = (("reservations_id", "seats_id"),)


class Reservations(models.Model):
    id = models.AutoField(db_column="Id", primary_key=True)
    user_id = models.ForeignKey(
        UserData, models.DO_NOTHING, db_column="UserId", blank=True, null=True
    )
    seats = models.ManyToManyField(
        "Seats", through="ReservationSeat", related_name="reservations"
    )

    class Meta:
        managed = False
        db_table = "Reservations"
