using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Blood_Bank_Management_Application.Models;
using System.Buffers.Text;
using System.Xml.Linq;

namespace Blood_Bank_Management_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodBankController : ControllerBase
    {
        // In-memory list as the database.
        static List<BloodBankEntry> bloodbankentrydetails = new List<BloodBankEntry>
        {
            // Predefined entries
            new BloodBankEntry
            {
                Id = 1,
                DonorName = "Ravi Sharma",
                Age = 27,
                BloodType = "A+",
                ContactInfo = "ravi.sharma@gmail.com",
                Quantity = 500,
                CollectionDate = new DateTime(2024, 11, 10),
                ExpirationDate = new DateTime(2024, 12, 10),
                Status = "Available"  // Status Available if Expiration Date is due.
            },
            new BloodBankEntry
            {
                Id = 2,
                DonorName = "Priya Singh",
                Age = 24,
                BloodType = "O-",
                ContactInfo = "priya.singh@gmail.com",
                Quantity = 450,
                CollectionDate = new DateTime(2024, 11, 29),
                ExpirationDate = new DateTime(2024, 12, 29),
                Status = "Requested"  // Status Requested if Collection Date is due.
            },
            new BloodBankEntry
            {
                Id = 3,
                DonorName = "Arjun Mehta",
                Age = 30,
                BloodType = "B+",
                ContactInfo = "arjun.mehta@gmail.com",
                Quantity = 300,
                CollectionDate = new DateTime(2024, 9, 12),
                ExpirationDate = new DateTime(2024, 10, 12),
                Status = "Expired"  // Status Expired if Expiration Date is passed.
            },
            new BloodBankEntry
            {
                Id = 4,
                DonorName = "Neha Verma",
                Age = 32,
                BloodType = "AB-",
                ContactInfo = "neha.verma@gmail.com",
                Quantity = 350,
                CollectionDate = new DateTime(2024, 11, 18),
                ExpirationDate = new DateTime(2024, 12, 18),
                Status = "Available"
            },
            new BloodBankEntry
            {
                Id = 5,
                DonorName = "Rahul Patel",
                Age = 28,
                BloodType = "O+",
                ContactInfo = "rahul.patel@gmail.com",
                Quantity = 400,
                CollectionDate = new DateTime(2024, 11, 14),
                ExpirationDate = new DateTime(2024, 12, 14),
                Status = "Available"
            },
            new BloodBankEntry
            {
                Id = 6,
                DonorName = "Anjali Nair",
                Age = 26,
                BloodType = "A-",
                ContactInfo = "anjali.nair@gmail.com",
                Quantity = 480,
                CollectionDate = new DateTime(2024, 11, 25),
                ExpirationDate = new DateTime(2024, 12, 25),
                Status = "Requested"
            },
            new BloodBankEntry
            {
                Id = 7,
                DonorName = "Karan Gupta",
                Age = 35,
                BloodType = "B-",
                ContactInfo = "karan.gupta@gmail.com",
                Quantity = 320,
                CollectionDate = new DateTime(2024, 11, 11),
                ExpirationDate = new DateTime(2024, 12, 11),
                Status = "Available"
            },
            new BloodBankEntry
            {
                Id = 8,
                DonorName = "Meera Iyer",
                Age = 29,
                BloodType = "AB+",
                ContactInfo = "meera.iyer@gmail.com",
                Quantity = 500,
                CollectionDate = new DateTime(2024, 10, 09),
                ExpirationDate = new DateTime(2024, 11, 09),
                Status = "Expired"
            }
        };


        // Retrieve all blood bank entries.
        [HttpGet]
        public ActionResult<IEnumerable<BloodBankEntry>> GetAllEntries ()
        {
            return bloodbankentrydetails;
        }


        // Retrieve a blood bank entry for the specific Id.
        [HttpGet("{id}")]
        public ActionResult<BloodBankEntry> GetEntryById (int id)
        {
            var entry = bloodbankentrydetails.Find(x => x.Id == id); // Checks if the entry is present in bloodbankentrydetails.
            if (entry == null) // If the entry is not there.
            {
                return NotFound();
            }
            return entry;
        }


        // Add a new blood bank entry.
        [HttpPost]
        public ActionResult<BloodBankEntry> AddNewEntry (BloodBankEntry newEntry)
        {
            if (newEntry == null) // Checks if the new entry is null.
            {
                return BadRequest("Entry cannot be null.");
            }

            // If the entry is not null.
            newEntry.Id = bloodbankentrydetails.Any() ? bloodbankentrydetails.Max(x => x.Id) + 1 : 1; // Autogenerated Id Number.
            newEntry.Status = "";

            // To update the status based on Collection Date, Expiration Date and Current Date.
            if (newEntry.CollectionDate > DateTime.Now)
            {
                newEntry.Status = "Requested";
            }
            else if (newEntry.ExpirationDate < DateTime.Now)
            {
                newEntry.Status = "Expired";
            }
            else
            {
                newEntry.Status = "Available";
            }

            bloodbankentrydetails.Add(newEntry);

            return CreatedAtAction(nameof(GetEntryById), new { id = newEntry.Id }, newEntry);
        }


        // Update an existing blood bank entry by its Id.
        [HttpPut("{id}")]
        public IActionResult UpdateAnEntry(int id, BloodBankEntry updatedEntry)
        {
            var entry = bloodbankentrydetails.Find(x => x.Id == id); // Checks if the entry is present in bloodbankentrydetails.

            if (entry == null) // If the entry is not there.
            {
                return NotFound();
            }

            // Update the exsisting entry.
            entry.DonorName = updatedEntry.DonorName;
            entry.Age = updatedEntry.Age;
            entry.BloodType = updatedEntry.BloodType;
            entry.ContactInfo = updatedEntry.ContactInfo;
            entry.Quantity = updatedEntry.Quantity;
            entry.CollectionDate = updatedEntry.CollectionDate;
            entry.ExpirationDate = updatedEntry.ExpirationDate;
            entry.Status = updatedEntry.Status;

            return NoContent();
        }


        // Delete a blood bank entry by its Id.
        [HttpDelete("{id}")]
        public IActionResult DeleteAnEntry(int id)
        {
            var entry = bloodbankentrydetails.Find(x => x.Id == id); // Checks if the entry is present in bloodbankentrydetails.

            if (entry == null) // If the entry is not there.
            {
                return NotFound();
            }

            bloodbankentrydetails.Remove(entry);

            return NoContent();
        }


        // Retrieve a paginated list of blood bank entries.
        [HttpGet("page")]
        public ActionResult<IEnumerable<BloodBankEntry>> GetPage(int page = 1, int size = 5)
        {
            // Calculates the entries to be displayed in the page by multiplying page number with its size. 
            var pagedEntries = bloodbankentrydetails.Skip((page - 1) * size).Take(size).ToList(); 
            return pagedEntries;
        }


        // Search for blood bank entries based on blood type.
        [HttpGet("search/byBloodType")]
        public IActionResult SearchByBloodType(string bloodType)
        {
            if (string.IsNullOrEmpty(bloodType)) // Checks if the string is empty.
            {
                return BadRequest("Blood type is required.");
            }

            var result = bloodbankentrydetails.Where(e => e.BloodType.Equals(bloodType, StringComparison.OrdinalIgnoreCase)).ToList();

            if (!result.Any()) // If there is no entries for that specific search.
            {
                return NotFound("No entries found with the specified blood type.");
            }

            return Ok(result);
        }


        // Search for blood bank entries by status
        [HttpGet("search/byStatus")]
        public IActionResult SearchByStatus(string status)
        {
            if (string.IsNullOrEmpty(status)) // Checks if the string is empty.
            {
                return BadRequest("Status is required.");
            }

            var result = bloodbankentrydetails.Where(e => e.Status.Equals(status, StringComparison.OrdinalIgnoreCase)).ToList();

            if (!result.Any()) // If there is no entries for that specific search.
            {
                return NotFound("No entries found with the specified status.");
            }

            return Ok(result);
        }


        // Search for donors by name.
        [HttpGet("search/byDonorName")]
        public IActionResult SearchByDonorName(string donorName)
        {
            if (string.IsNullOrEmpty(donorName)) // Checks if the string is empty.
            {
                return BadRequest("Donor name is required.");
            }

            var result = bloodbankentrydetails.Where(e => e.DonorName.Contains(donorName, StringComparison.OrdinalIgnoreCase)).ToList();

            if (!result.Any()) // If there is no entries for that specific search.
            {
                return NotFound("No entries found with the specified donor name.");
            }

            return Ok(result);
        }


        // Filter entries based on multiple search parameters.
        [HttpGet("filter")]
        public IActionResult FilterEntries(
            string? bloodType = null,
            string? status = null,
            int? minAge = null,
            int? maxAge = null,
            int? minQuantity = null,
            int? maxQuantity = null,
            DateTime? minCollectionDate = null,
            DateTime? maxCollectionDate = null,
            DateTime? minExpirationDate = null,
            DateTime? maxExpirationDate = null
        )
        {
            var result = bloodbankentrydetails.AsQueryable();

            // Appling filters based on query parameters.
            if (!string.IsNullOrEmpty(bloodType))
                result = result.Where(e => e.BloodType.Equals(bloodType, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(status))
                result = result.Where(e => e.Status.Equals(status, StringComparison.OrdinalIgnoreCase));

            if (minAge.HasValue)
                result = result.Where(e => e.Age >= minAge.Value);

            if (maxAge.HasValue)
                result = result.Where(e => e.Age <= maxAge.Value);

            if (minQuantity.HasValue)
                result = result.Where(e => e.Quantity >= minQuantity.Value);

            if (maxQuantity.HasValue)
                result = result.Where(e => e.Quantity <= maxQuantity.Value);

            if (minCollectionDate.HasValue)
                result = result.Where(e => e.CollectionDate >= minCollectionDate.Value);

            if (maxCollectionDate.HasValue)
                result = result.Where(e => e.CollectionDate <= maxCollectionDate.Value);

            if (minExpirationDate.HasValue)
                result = result.Where(e => e.ExpirationDate >= minExpirationDate.Value);

            if (maxExpirationDate.HasValue)
                result = result.Where(e => e.ExpirationDate <= maxExpirationDate.Value);

            var filteredResult = result.ToList();

            if (!filteredResult.Any()) // If there is no entries for that specific filter.
                return NotFound("No matching blood bank entries found.");

            return Ok(filteredResult);
        }


        // Sort entries by a specified property and order.
        [HttpGet("sort")]
        public ActionResult<IEnumerable<BloodBankEntry>> SortEntries(string sortby = "BloodType", string sortorder = "asc")
        {
            var res = bloodbankentrydetails.AsQueryable();


            // Check the property to sort by and the sort order(ascending or descending).
            if (sortby.ToLower() == "bloodtype") 
            {
                res = sortorder.ToLower() == "asc" ? res.OrderBy(i => i.BloodType) : res.OrderByDescending(i => i.BloodType);
            }
            else if (sortby.ToLower() == "age")
            {
                res = sortorder.ToLower() == "asc" ? res.OrderBy(i => i.Age) : res.OrderByDescending(i => i.Age);
            }
            else if (sortby.ToLower() == "quantity")
            {
                res = sortorder.ToLower() == "asc" ? res.OrderBy(i => i.Quantity) : res.OrderByDescending(i => i.Quantity);
            }
            else if (sortby.ToLower() == "collectiondate")
            {
                res = sortorder.ToLower() == "asc" ? res.OrderBy(i => i.CollectionDate) : res.OrderByDescending(i => i.CollectionDate);
            }
            else if (sortby.ToLower() == "expirationdate")
            {
                res = sortorder.ToLower() == "asc" ? res.OrderBy(i => i.ExpirationDate) : res.OrderByDescending(i => i.ExpirationDate);
            }
            else
            {
                return BadRequest("No such property exists.");
            }
            return res.ToList();
        }
    }
}