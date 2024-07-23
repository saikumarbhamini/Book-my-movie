using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace BookMovieTicket.Models;

public class Reservation
{
    public int Id { get; set; }
    public UserData? UserId { get; set; }
    public ScreenShowMapper? ScreenShowId { get; set; }
    [MaxLength(225)]
    public string? ReservationCode { get; set; }
    [JsonIgnore]
    public ICollection<Seat>? Seats { get; set; }
}