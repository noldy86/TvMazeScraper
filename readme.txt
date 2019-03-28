1. Ensure docker setup in windows container mode
2. Open in Visual studio
3. Update Database
4. Run TvMazeScraper configuration
5. Go to swagger: https://localhost:5001/index.html (if not already open)
6. in swagger: run import POST: /api/scraperservice
7. import of data is done per approx 250 shows, so you can proceed to next step whenever possible (note that not all data will be there if import is still running)
8. in swagger: call api for result api/show choose page and pagesize if needed
9. see the requested result.