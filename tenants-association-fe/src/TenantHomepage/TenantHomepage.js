import * as React from 'react';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import Box from '@mui/material/Box';
import Grid from '@mui/material/Grid';
import Typography from '@mui/material/Typography';
import Radio from '@mui/material/Radio';
import RadioGroup from '@mui/material/RadioGroup';
import FormControlLabel from '@mui/material/FormControlLabel';
import FormControl from '@mui/material/FormControl';
import FormLabel from '@mui/material/FormLabel';

const TenantHomepage=()=>{


    function createData(name,date) {
      return { name, date };
    }
    
    const rows = [
      createData('Reabilitare blocuri Brazda lui Novac', "Vezi mai multe"),
      createData('Totul despre fondul de rulment', "Vezi mai multe"),
      createData('Acordul asociatiei,obligatoriu pentru a putea adopta mai mult de 2 caini', "Vezi mai multe"),
      createData('Abuz in asociatii? Care sunt posibilitatile tale ca proprietar', "Vezi mai multe"),
      createData('5 reguli de urmat de catre proprietar', "Vezi mai multe"),
    ];
    const rows2 = [
        createData('Gaze', "04.04.2024"),
        createData('Intretinere', "01.02.2024"),
        createData('Apa', "19.12.2023"),
        createData('Curent', "04.02.2023"),
        createData('Curent', "05.03.2024"),
      ];
      return (
        <Box sx={{ flexGrow: 1, mt:7 }}>
        <Grid
  container
  direction="row"
  justifyContent="center"
  alignItems="center"
   spacing={4}> 
        <Grid item>
        <Typography
          sx={{ flex: '1 1 100%' }}
          variant="h5"
          id="tableTitle"
          component="div"
        >
         New announcements:
        </Typography>
        <TableContainer component={Paper}>
          <Table sx={{ minWidth: 650 }} aria-label="simple table">
            <TableBody>
              {rows.map((row) => (
                <TableRow
                  key={row.name}
                  sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                >
                  <TableCell component="th" scope="row">
                    {row.name}
                  </TableCell>
                  <TableCell align="right">{row.date}</TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
        </Grid>
        <Grid item>
        <Typography
          sx={{ flex: '1 1 100%' }}
          variant="h5"
          id="tableTitle"
          component="div"
        >
       Unpaid invoices:
        </Typography>
        <TableContainer component={Paper}>
          <Table sx={{ minWidth: 650 }} aria-label="simple table">

            <TableBody>
              {rows2.map((row) => (
                <TableRow
                  key={row.name}
                  sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                >
                  <TableCell component="th" scope="row">
                    {row.name}
                  </TableCell>
                  <TableCell align="right">{row.date}</TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
        </Grid>
        </Grid>
        <Grid   container
  direction="row"
  justifyContent="center"
  alignItems="center"
   spacing={4}
   sx={{ mt:7 }}>
    <Grid item>
    <FormControl>
      <FormLabel id="demo-radio-buttons-group-label">La ce ora sa vina deratizarea?</FormLabel>
      <RadioGroup
        aria-labelledby="demo-radio-buttons-group-label"
        defaultValue="female"
        name="radio-buttons-group"
      >
        <FormControlLabel value="female" control={<Radio />} label="8:30" />
        <FormControlLabel value="male" control={<Radio />} label="9:00" />
        <FormControlLabel value="other" control={<Radio />} label="9:30" />
      </RadioGroup>
    </FormControl>
    </Grid>
        </Grid>
        </Box>
      );
    }
    
export default TenantHomepage;