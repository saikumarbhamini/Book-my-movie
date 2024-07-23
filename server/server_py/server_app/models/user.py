#################################################################################
import re
import uuid

#################################################################################
from django.contrib.auth.models import AbstractUser, Group, Permission
from django.db import models
from rest_framework.exceptions import ValidationError

#################################################################################


class UserData(AbstractUser):
    id = models.UUIDField(primary_key=True, default=uuid.uuid4, editable=False)
    phone_number = models.CharField(max_length=20, unique=True, null=False, blank=False)

    groups = models.ManyToManyField(
        Group,
        blank=True,
        related_name="server_app_user_set",
        help_text="The group this user belongs to.",
        related_query_name="user",
    )
    user_permissions = models.ManyToManyField(
        Permission,
        blank=True,
        related_name="server_app_user_set",
        related_query_name="user",
        help_text="Specific permissions for this user.",
    )

    # def save(self, *args, **kwargs):
    #     if self.phone_number is not None:
    #         is_valid = re.compile("(91)[6-9][0-9]{9}").match(self.phone_number)
    #         if not is_valid:
    #             raise ValidationError(
    #                 f"{self.phone_number} is not a valid phone number"
    #             )
    #     super().save(*args, **kwargs)

    class Meta:
        app_label = 'server_app'
        db_table = "user_data"
        verbose_name = "UserData"
        verbose_name_plural = "UsersData"
