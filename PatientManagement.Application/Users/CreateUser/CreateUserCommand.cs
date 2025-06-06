﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Application.Users.CreateUser;
public record CreateUserCommand(Guid UserId, string FullName) : IRequest<Guid>;

