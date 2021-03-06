﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.courseVenueClass
{
    public class courseVenueAccess
    {


        public wpCourseVenue GetCourseDetails(string course)
        {
            wpCourseVenue courseVenue = null;
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@course",course)
            };
            using (DataTable table = dbHelper.ExecuteParamerizedSelectCommand("uspCourseVenue", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count == 1)
                {
                    DataRow row = table.Rows[0];

                    courseVenue = new wpCourseVenue();

                    courseVenue.CourseCode = row["CRS_CODE"].ToString();
                    courseVenue.CourseDescription = row["CRS_DESCRIPTION"].ToString();
                    courseVenue.RoomCode = row["ROOM_CODE"].ToString();
                }
            }
            return courseVenue;
        }

        public List<wpCourseVenue> GetCourseList(string course)
        {
            List<wpCourseVenue> listCourseVenue = null;
            SqlParameter[] parameters = new SqlParameter[]
              {
                    new SqlParameter("@course",course),
              };

            using (DataTable table = dbHelper.ExecuteParamerizedSelectCommand("uspCourseVenue", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count > 0)
                {
                    listCourseVenue = new List<wpCourseVenue>();
                    foreach (DataRow row in table.Rows)
                    {
                        wpCourseVenue courseVenue = new wpCourseVenue();
                        courseVenue.CourseCode = row["CRS_CODE"].ToString();
                        courseVenue.CourseDescription = row["CRS_DESCRIPTION"].ToString();
                        courseVenue.RoomCode = row["ROOM_CODE"].ToString();
                        listCourseVenue.Add(courseVenue);
                    }
                }


            }
            return listCourseVenue;
        }
    }
}

